using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMS.dal;

namespace LMS
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        private static readonly string connString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            buttonerror.Visible = false;
            GridView1.DataBind();
        }
        //add button
        protected void Button2_Click(object sender, EventArgs e)
        {
            Mydal objMyDal = new Mydal();
            string aid = TextBox1.Text;
            string aname = TextBox2.Text;
            try
            {
                if (aname == string.Empty)
                {
                    buttonerror.Visible = true;
                    buttonerror.ForeColor = System.Drawing.Color.IndianRed;
                    buttonerror.Text = "*Author Name cannot be empty";
                }
                else
                {
                    int output = objMyDal.addAuthor(aid, aname);

                    if (output == 2)
                    {
                        buttonerror.Visible = true;
                        buttonerror.ForeColor = System.Drawing.Color.IndianRed;
                        buttonerror.Text = "*Unique Name required";
                    }
                    else if (output == 1)
                    {
                        buttonerror.Visible = true;
                        buttonerror.ForeColor = System.Drawing.Color.IndianRed;
                        buttonerror.Text = "*Unique ID required";
                    }
                    else if (output == 0)
                    {
                        buttonerror.Visible = true;
                        buttonerror.ForeColor = System.Drawing.Color.Green;
                        buttonerror.Text = "*Added successfully";
                        clear();
                        GridView1.DataBind();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL error" + ex.Message.ToString());
            }
        }
        //update button
        protected void Button3_Click(object sender, EventArgs e)
        {
            Mydal objMyDal = new Mydal();
            string aid = TextBox1.Text;
            string aname = TextBox2.Text;
            try
            {
                if (aname == string.Empty)
                {
                    buttonerror.Visible = true;
                    buttonerror.ForeColor = System.Drawing.Color.IndianRed;
                    buttonerror.Text = "*Author Name cannot be empty";
                }
                else
                {
                    int output = objMyDal.upAuthor(aid, aname);

                    if (output == 0)
                    {
                        buttonerror.Visible = true;
                        buttonerror.ForeColor = System.Drawing.Color.IndianRed;
                        buttonerror.Text = "*Invalid Author ID";
                    }
                    else if (output == 1)
                    {
                        buttonerror.Visible = true;
                        buttonerror.ForeColor = System.Drawing.Color.IndianRed;
                        buttonerror.Text = "*Author cannot be updated";
                    }
                    else
                    {
                        buttonerror.Visible = true;
                        buttonerror.ForeColor = System.Drawing.Color.Green;
                        buttonerror.Text = "*Updated successfully";
                        clear();
                        GridView1.DataBind();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL error" + ex.Message.ToString());
            }
}
        //delete button
        protected void Button4_Click(object sender, EventArgs e)
        {
            Mydal objMyDal = new Mydal();
            string aid = TextBox1.Text;

           
            int output = objMyDal.delAuthor(aid);
            try
            {
                if (output == 0)
                {
                    buttonerror.Visible = true;
                    buttonerror.ForeColor = System.Drawing.Color.IndianRed;
                    buttonerror.Text = "*Invalid Author ID";
                }
                else if (output == 1)
                {
                    buttonerror.Visible = true;
                    buttonerror.ForeColor = System.Drawing.Color.IndianRed;
                    buttonerror.Text = "*Author cannot be deleted";
                }
                else
                {
                    buttonerror.Visible = true;
                    buttonerror.ForeColor = System.Drawing.Color.Green;
                    buttonerror.Text = "*Deleted successfully";
                    clear();
                    GridView1.DataBind();
                }
            }
            catch (SqlException ex)
            {
                //nothing
                Console.WriteLine("SQL error" + ex.Message.ToString());
            }
        }
        //user defined functions
        void clear()
        {
            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;
        }

    }
}