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
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loginerroradmin.Visible = false;
        }
        //login button click
        protected void Button1_Click(object sender, EventArgs e)
        {
            string adminID = TextBox1.Text;
            string password = TextBox2.Text;
            try
            {
                if (adminLogin(adminID, password))
                {
                    setSessions(adminID, password);
                    Response.Redirect("admin_profile.aspx");
                }
                else
                {
                    loginerroradmin.Visible = true;
                    loginerroradmin.ForeColor = System.Drawing.Color.IndianRed;
                    loginerroradmin.Text = "*Invalid Credentials";
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL error" + ex.Message.ToString());
            }
        }
        //user defined functions
        bool adminLogin(string adminID, string password)
        {
            Mydal objMyDal = new Mydal();
            int found = objMyDal.loginAdmin(adminID, password);
            if (found == 0)
                return false;
            else return true;
        }
        void setSessions(string adminID, string password)
        {
            Mydal objMyDal = new Mydal();
            DataTable dt = new DataTable();
            objMyDal.adminProfileLoad(adminID, ref dt);
            Session["username"] = adminID;
            Session["userPassword"] = password;
            Session["fullname"] = dt.Rows[0]["name"].ToString();
            Session["role"] = "admin";
        }
    }
}