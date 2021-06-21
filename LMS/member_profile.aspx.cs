using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMS.dal;

namespace LMS
{
    public partial class WebForm8 : System.Web.UI.Page
    {

        private static readonly string connString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            updated.Visible = false;
            passerror.Visible = false;
            newpasserr.Visible = false;
            passerror2.Visible = false;
            phnoError.Visible = false;
            if (!IsPostBack)
                loadMemberProfile();
        }
        //update button click
        protected void Button1_Click(object sender, EventArgs e)
        {
            bool check = false;
            string memberID = Session["username"].ToString();
            string name = TextBox3.Text;
            string dob = TextBox1.Text;
            string email = TextBox2.Text;
            string phonenum = TextBox4.Text;
            string address = TextBox5.Text;
            string gender;
            if (RadioButtonList1.SelectedValue.Equals("Male"))
                gender = "Male";
            else
                gender = "Female";
            string oldpass = TextBox6.Text;
            string newpassword = TextBox7.Text;
            string newpassword2 = TextBox9.Text;

            try
            {
                if (phonenum[0] != '0' || phonenum[1] != '3')
                {
                    phnoError.Visible = true;
                    phnoError.ForeColor = System.Drawing.Color.IndianRed;
                    phnoError.Text = "*Phone Number should start with 03";
                }
                if (oldpass == string.Empty)
                {
                    newpassword = Session["userPassword"].ToString();
                    newpassword2 = Session["userPassword"].ToString();
                    check = true;
                }
                else
                {
                    if (oldpass != Session["userPassword"].ToString())
                    {
                        passerror.Visible = true;
                        passerror.ForeColor = System.Drawing.Color.IndianRed;
                        passerror.Text = "*Incorrect OLD Password";
                    }
                    else
                    {
                        if ((newpassword == string.Empty || newpassword2 == string.Empty))
                        {
                            newpasserr.Visible = true;
                            newpasserr.ForeColor = System.Drawing.Color.IndianRed;
                            newpasserr.Text = "*New Password fields cannot be left empty";
                        }
                        else if (newpassword != newpassword2)
                        {
                            newpasserr.Visible = true;
                            newpasserr.ForeColor = System.Drawing.Color.IndianRed;
                            newpasserr.Text = "*Passwords do not match";
                        }
                        else
                            check = true;
                    }

                }

                if (check == true)
                {
                    updateMember(memberID, name, phonenum, email, newpassword, gender, dob, address);
                    updated.Visible = true;
                    updated.ForeColor = System.Drawing.Color.Green;
                    updated.Text = "*Updated successfully";
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL error" + ex.Message.ToString());
            }
        }
        //user defined functions
        void loadMemberProfile()
        {
            SqlConnection con = new SqlConnection(connString);
            try
            {
                string memberID = Session["username"].ToString();
                Mydal objMyDal = new Mydal();
                DataTable dt = new DataTable();
                objMyDal.memberProfileLoad(memberID, ref dt);

                if (dt.Rows.Count > 0)
                {
                    TextBox8.Text = memberID;
                    TextBox3.Text = dt.Rows[0]["name"].ToString();
                    TextBox4.Text = dt.Rows[0]["ph_no"].ToString();
                    RadioButtonList1.SelectedValue = dt.Rows[0]["gender"].ToString();
                    TextBox5.Text = dt.Rows[0]["address"].ToString();
                    TextBox1.Text = (Convert.ToDateTime(dt.Rows[0]["dob"]).ToString("yyyy-MM-dd"));
                    TextBox2.Text = dt.Rows[0]["email"].ToString();
                    TextBox10.Text = dt.Rows[0]["mem_pkg_id"].ToString();
                    TextBox11.Text = dt.Rows[0]["duration"].ToString();
                    TextBox12.Text = dt.Rows[0]["bk_count"].ToString();
                    TextBox13.Text = dt.Rows[0]["amount"].ToString();

                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL error" + ex.Message.ToString());
            }
        }
        void updateMember(string memberID, string name, string phonenum, string email, string password, string gender, string dob, string address)
        {
            SqlConnection con = new SqlConnection(connString);
            Mydal objMyDal = new Mydal();
            objMyDal.upMember(memberID, name, phonenum, email, password, gender, dob, address);
            Session["userPassword"] = password;
        }
    }
}