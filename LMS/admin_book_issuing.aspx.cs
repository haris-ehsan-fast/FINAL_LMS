using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMS.dal;
using System.Data;
using System.Data.SqlClient;

namespace LMS
{
    public partial class WebForm11 : System.Web.UI.Page
    {
        private static readonly string connString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            iderror.Visible = false;
            issue.Visible = false;
            returnerr.Visible = false;
            GridView1.DataBind();
        }
        //go button
        protected void Button1_Click(object sender, EventArgs e)
        {
            string mID = TextBox2.Text;
            Mydal objMyDal1 = new Mydal();
            DataTable dt1 = new DataTable();
            string bID = TextBox1.Text;
            Mydal objMyDal2 = new Mydal();
            DataTable dt2 = new DataTable();

            objMyDal1.memberProfileLoad(mID, ref dt1);
            objMyDal2.bookLoad(bID, ref dt2);
            try
            {
                if (dt1.Rows.Count > 0 && dt2.Rows.Count > 0)
                {
                    TextBox3.Text = dt1.Rows[0][1].ToString();
                    TextBox4.Text = dt2.Rows[0][1].ToString();
                }
                else
                {
                    clear();
                    iderror.Visible = true;
                    iderror.ForeColor = System.Drawing.Color.IndianRed;
                    iderror.Text = "*Invalid Member ID or Book ID";
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL error" + ex.Message.ToString());
            }
        }
        //issue button
        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkMemberExists() && checkBookExists())
                {
                    if (checkIssueExists())
                    {
                        if (!checkEnoughBooks())
                        {
                            issue.Visible = true;
                            issue.ForeColor = System.Drawing.Color.IndianRed;
                            issue.Text = "*There is no available stock for this book";
                        }
                        else
                        {
                            issue.Visible = true;
                            issue.ForeColor = System.Drawing.Color.IndianRed;
                            issue.Text = "*Same book cannot be issued twice";
                        }
                    }
                    else
                    {
                        string mID = TextBox2.Text;
                        string bID = TextBox1.Text;
                        string issueD = TextBox5.Text;
                        Mydal objMyDal1 = new Mydal();
                        int output = objMyDal1.issueBook(mID, bID, issueD);
                        if (output == 0)
                        {
                            issue.Visible = true;
                            issue.ForeColor = System.Drawing.Color.IndianRed;
                            issue.Text = "*Member has exceeded book limit";
                        }
                        else
                        {
                            clear();
                            issue.Visible = true;
                            issue.ForeColor = System.Drawing.Color.Green;
                            issue.Text = "*Issued successfully";
                            GridView1.DataBind();
                        }
                    }
                }
                else
                {
                    issue.Visible = true;
                    issue.ForeColor = System.Drawing.Color.IndianRed;
                    issue.Text = "*Invalid Member ID or Book ID";
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL error" + ex.Message.ToString());
            }
        }
        //return button
        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkIssueExists())
                {
                    string mID = TextBox2.Text;
                    string bID = TextBox1.Text;
                    string retD = TextBox6.Text;
                    Mydal objMyDal1 = new Mydal();
                    int output = objMyDal1.returnBook(mID, bID, retD);
                    if (output == 0)
                    {
                        returnerr.Visible = true;
                        returnerr.ForeColor = System.Drawing.Color.IndianRed;
                        returnerr.Text = "*Book already returned";
                    }
                    else
                    {
                        clear();
                        returnerr.Visible = true;
                        returnerr.ForeColor = System.Drawing.Color.Green;
                        returnerr.Text = "*Returned successfully";
                        GridView1.DataBind();
                    }
                }
                else
                {
                    returnerr.Visible = true;
                    returnerr.ForeColor = System.Drawing.Color.IndianRed;
                    returnerr.Text = "*Invalid Member ID or Book ID";
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL error" + ex.Message.ToString());
            }
        }

        //user defined functions
        bool checkMemberExists()
        {
            string mID = TextBox2.Text;
            Mydal objMyDal1 = new Mydal();
            DataTable dt1 = new DataTable();
            objMyDal1.memberProfileLoad(mID, ref dt1);
            if (dt1.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        bool checkBookExists()
        {
            string bID = TextBox1.Text;
            Mydal objMyDal2 = new Mydal();
            DataTable dt2 = new DataTable();
            objMyDal2.bookLoad(bID, ref dt2);
            if (dt2.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        bool checkEnoughBooks()
        {
            string bID = TextBox1.Text;
            Mydal objMyDal2 = new Mydal();
            DataTable dt2 = new DataTable();
            objMyDal2.bookLoad(bID, ref dt2);
            if (dt2.Rows.Count > 0 && Convert.ToInt32(dt2.Rows[0][5].ToString()) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        bool checkIssueExists()
        {
            string mID = TextBox2.Text;
            string bID = TextBox1.Text;
            Mydal objMyDal = new Mydal();
            DataTable dt = new DataTable();
            objMyDal.issueLoad(mID, bID, ref dt);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
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
        }
        //exceeds expected date 
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //Check your condition here
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if (today > dt && e.Row.Cells[6].Text == "&nbsp;")
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        
        
    }
}