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
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //signup button click
        protected void Button1_Click(object sender, EventArgs e)
        {
            Mydal objMyDal = new Mydal();
            string mem_id = TextBox8.Text;
            string name = TextBox3.Text;
            string pass = TextBox6.Text;
            string ph_no = TextBox4.Text;
            string gender = RadioButtonList1.SelectedValue;
            string address = TextBox5.Text;
            string dob = TextBox1.Text;
            string email = TextBox2.Text;
            string confirmpass = TextBox7.Text;
            int found;
            phnoError.Visible = false;
            idExists.Visible = false;
            passerror.Visible = false;
            try
            {
                if (pass != confirmpass)
                {
                    passerror.Visible = true;
                    passerror.ForeColor = System.Drawing.Color.IndianRed;
                    passerror.Text = "*Passwords do not match.";
                }
                else if (ph_no[0] != '0' || ph_no[1] != '3')
                {
                    phnoError.Visible = true;
                    phnoError.ForeColor = System.Drawing.Color.IndianRed;
                    phnoError.Text = "*Phone Number should start with 03";
                }
                else
                {
                    found = objMyDal.signup(mem_id, name, pass, ph_no, gender, address, dob, email);

                    if (found == 1)
                    {
                        idExists.Visible = true;
                        idExists.ForeColor = System.Drawing.Color.IndianRed;
                        idExists.Text = "*ID exists already. Enter another ID.";
                    }
                    if (found == 2)
                    {
                        Response.Redirect("member_login.aspx");

                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL error" + ex.Message.ToString());
            }
        }
    }
}