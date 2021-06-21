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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loginerror.Visible = false;
        }
        //login button click
        protected void Button1_Click(object sender, EventArgs e)
        {
            string memberID = TextBox1.Text;
            string password = TextBox2.Text;
            try
            {
                if (memberLogin(memberID, password))
                {
                    setSessions(memberID, password);
                    Response.Redirect("member_profile.aspx");
                }
                else
                {
                    loginerror.Visible = true;
                    loginerror.ForeColor = System.Drawing.Color.IndianRed;
                    loginerror.Text = "*Invalid Credentials";
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL error" + ex.Message.ToString());
            }
        }
        //user defined functions
        bool memberLogin(string memberID, string password)
        {
            Mydal objMyDal = new Mydal();
            int found = objMyDal.loginMember(memberID, password);
            if (found == 0)
                return false;
            else return true;
        }
        void setSessions(string memberID, string password)
        {
            Mydal objMyDal = new Mydal();
            DataTable dt = new DataTable();
            objMyDal.memberProfileLoad(memberID, ref dt);
            Session["username"] = memberID;
            Session["userPassword"] = password;
            Session["fullname"] = dt.Rows[0]["name"].ToString();
            Session["role"] = "member";
        }
       
    }
}