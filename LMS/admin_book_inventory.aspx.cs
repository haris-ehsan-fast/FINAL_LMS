using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMS.dal;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace LMS
{
    public partial class WebForm13 : System.Web.UI.Page
    {
        private static readonly string connString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
        static string global_filepath;
        static int global_actual_stock, global_current_stock, global_issued_books;
        protected void Page_Load(object sender, EventArgs e)
        {
            buttonerror.Visible = false;
            iderror.Visible = false;
            GridView1.DataBind();
            if (!IsPostBack)
                fillAuthorPublisherValues();
        }
        //go button
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connString);
            try
            {
                string bID = TextBox1.Text;
                Mydal objMyDal = new Mydal();
                DataTable dt = new DataTable();


                objMyDal.bookLoad(bID, ref dt);

                if (dt.Rows.Count > 0)
                {
                    TextBox2.Text = dt.Rows[0]["title"].ToString();
                    DropDownList1.SelectedValue = dt.Rows[0]["lingo"].ToString().Trim();
                    DropDownList2.SelectedValue = dt.Rows[0]["publ"].ToString().Trim();
                    DropDownList3.SelectedValue = dt.Rows[0]["author"].ToString().Trim();
                    TextBox3.Text = dt.Rows[0]["publ_yr"].ToString();
                    ListBox1.ClearSelection();
                    for (int j = 0; j < ListBox1.Items.Count; j++)
                    {
                        if (ListBox1.Items[j].ToString() == dt.Rows[0]["genre"].ToString())
                            ListBox1.Items[j].Selected = true;
                        else
                            ListBox1.Items[j].Selected = false;
                    }
                    TextBox4.Text = dt.Rows[0][4].ToString().Trim(); // actual stock
                    TextBox5.Text = dt.Rows[0][5].ToString().Trim(); //current stock
                    TextBox6.Text = dt.Rows[0][9].ToString(); //description

                    global_actual_stock = Convert.ToInt32(dt.Rows[0]["num_act"].ToString().Trim());
                    global_current_stock = Convert.ToInt32(dt.Rows[0]["num_curr"].ToString().Trim());
                    global_issued_books = global_actual_stock - global_current_stock;
                    global_filepath = dt.Rows[0]["img_link"].ToString();
                }
                else
                {
                    iderror.Visible = true;
                    iderror.ForeColor = System.Drawing.Color.IndianRed;
                    iderror.Text = "*Invalid Book ID";
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("SQL error" + ex.Message.ToString());
            }
        }
        //add button
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox1.Text == string.Empty ||
                    TextBox2.Text == string.Empty ||
                    TextBox3.Text == string.Empty ||
                    TextBox4.Text == string.Empty ||
                    TextBox6.Text == string.Empty ||
                    DropDownList1.SelectedValue == string.Empty ||
                    DropDownList2.SelectedValue == string.Empty ||
                    DropDownList3.SelectedValue == string.Empty ||
                    ListBox1.SelectedValue == string.Empty)
                {
                    buttonerror.Visible = true;
                    buttonerror.ForeColor = System.Drawing.Color.IndianRed;
                    buttonerror.Text = "*Field cannot be empty";
                }
                else
                {
                    string bid = TextBox1.Text;
                    string title = TextBox2.Text;
                    string lang = DropDownList1.SelectedValue;
                    string pub = DropDownList2.SelectedValue;
                    string author = DropDownList3.SelectedValue;
                    int pubyear = Convert.ToInt32(TextBox3.Text);
                    string genre = ListBox1.SelectedValue;
                    int act = Convert.ToInt32(TextBox4.Text);
                    int curr = Convert.ToInt32(TextBox4.Text);
                    string des = TextBox6.Text;

                    string filepath = "~/bookinventory/mainbooks";
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    FileUpload1.SaveAs(Server.MapPath("bookinventory/" + filename));
                    filepath = "~/bookinventory/" + filename;

                    Mydal objMyDal = new Mydal();
                    int output = objMyDal.addBook(bid, title, lang, genre, act, curr, pubyear, pub, author, des, filepath);
                    if (output == 0)
                    {
                        clear();
                        buttonerror.Visible = true;
                        buttonerror.ForeColor = System.Drawing.Color.Green;
                        buttonerror.Text = "*Added successfully";
                        GridView1.DataBind();
                    }
                    else
                    {
                        buttonerror.Visible = true;
                        buttonerror.ForeColor = System.Drawing.Color.IndianRed;
                        buttonerror.Text = "*Invalid Book ID";
                    }

                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL error" + ex.Message.ToString());
            }

        }
        //update
        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox1.Text == string.Empty ||
                     TextBox2.Text == string.Empty ||
                     TextBox3.Text == string.Empty ||
                     TextBox4.Text == string.Empty ||
                     TextBox6.Text == string.Empty ||
                     DropDownList1.SelectedValue == string.Empty ||
                     DropDownList2.SelectedValue == string.Empty ||
                     DropDownList3.SelectedValue == string.Empty ||
                     ListBox1.SelectedValue == string.Empty)
                {
                    buttonerror.Visible = true;
                    buttonerror.ForeColor = System.Drawing.Color.IndianRed;
                    buttonerror.Text = "*Field cannot be empty";
                }
                else
                {
                    string bid = TextBox1.Text;
                    string title = TextBox2.Text;
                    string lang = DropDownList1.SelectedValue;
                    string pub = DropDownList2.SelectedValue;
                    string author = DropDownList3.SelectedValue;
                    int pubyear = Convert.ToInt32(TextBox3.Text);
                    string genre = ListBox1.SelectedValue;
                    int act = Convert.ToInt32(TextBox4.Text);
                    int curr = Convert.ToInt32(TextBox4.Text);
                    string des = TextBox6.Text;
                    string filepath = "~/bookinventory/mainbooks";
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    if (filename == "" || filename == null)
                    {
                        filepath = global_filepath;

                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("bookinventory/" + filename));
                        filepath = "~/bookinventory/" + filename;
                    }

                    Mydal objMyDal = new Mydal();
                    int output = objMyDal.upBook(bid, title, lang, genre, act, curr, pubyear, pub, author, des, filepath);
                    if (output == 1)
                    {
                        clear();
                        buttonerror.Visible = true;
                        buttonerror.ForeColor = System.Drawing.Color.Green;
                        buttonerror.Text = "*Updated successfully";
                        GridView1.DataBind();
                    }
                    else
                    {
                        buttonerror.Visible = true;
                        buttonerror.ForeColor = System.Drawing.Color.IndianRed;
                        buttonerror.Text = "*Invalid Book ID";
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL error" + ex.Message.ToString());
            }
        }
        //delete button
        protected void Button2_Click(object sender, EventArgs e)
        {
            string bid = TextBox1.Text;
            Mydal objMyDal = new Mydal();

            int output = objMyDal.delBook(bid);
            try
            {
                if (output == 0)
                {
                    buttonerror.Visible = true;
                    buttonerror.ForeColor = System.Drawing.Color.IndianRed;
                    buttonerror.Text = "*Invalid Book ID";
                }
                else if (output == 1)
                {
                    buttonerror.Visible = true;
                    buttonerror.ForeColor = System.Drawing.Color.IndianRed;
                    buttonerror.Text = "*Book cannot be deleted";
                }
                else
                {
                    buttonerror.Visible = true;
                    buttonerror.ForeColor = System.Drawing.Color.Green;
                    buttonerror.Text = "*Deleted successfully";
                    TextBox1.Text = string.Empty;
                    TextBox2.Text = string.Empty;
                    GridView1.DataBind();

                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL error" + ex.Message.ToString());
            }
        }
        //user defined functions
        void fillAuthorPublisherValues()
        {
            SqlConnection con = new SqlConnection(connString);
            try
            {
                Mydal objMyDal = new Mydal();
                DataTable dt1 = new DataTable();
                objMyDal.authorNameLoad(ref dt1);

                DropDownList3.DataSource = dt1;
                DropDownList3.DataValueField = "name";
                DropDownList3.DataBind();

                DataTable dt2 = new DataTable();
                objMyDal.publisherNameLoad(ref dt2);

                DropDownList2.DataSource = dt2;
                DropDownList2.DataValueField = "name";
                DropDownList2.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine("SQL error" + ex.Message.ToString());
            }

        }
        void clear()
        {
            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;
            TextBox3.Text = string.Empty;
            TextBox4.Text = string.Empty;
            TextBox5.Text = string.Empty;
            TextBox6.Text = string.Empty;
            ListBox1.ClearSelection();
        }
        
    }
}