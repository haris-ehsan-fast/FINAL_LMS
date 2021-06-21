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
    public partial class WebForm12 : System.Web.UI.Page
    {
        private static readonly string connString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            IDerror.Visible = false;
            delete.Visible = false;
            pkgerror.Visible = false;
            GridView1.DataBind();
        }
        //delete member permenantly button
        protected void Button1_Click(object sender, EventArgs e)
        {
            Mydal objMyDal = new Mydal();
            string mid = TextBox1.Text;
            
            int output = objMyDal.delMember(mid);
            try
            {
                if (output == 0)
                {
                    delete.Visible = true;
                    delete.ForeColor = System.Drawing.Color.IndianRed;
                    delete.Text = "*Invalid Member ID";
                }
                else if (output == 1)
                {
                    delete.Visible = true;
                    delete.ForeColor = System.Drawing.Color.IndianRed;
                    delete.Text = "*Member cannot be deleted";
                }
                else
                {
                    delete.Visible = true;
                    delete.ForeColor = System.Drawing.Color.Green;
                    delete.Text = "*Deleted successfully";
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
        //go button
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (!member())
                {
                    IDerror.Visible = true;
                    IDerror.ForeColor = System.Drawing.Color.IndianRed;
                    IDerror.Text = "*Invalid Member ID";
                }
            }
            catch (SqlException ex)
            {
                //nothing
                Console.WriteLine("SQL error" + ex.Message.ToString());
            }

        }
        //update button
        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connString);
            try
            {
                string userID = TextBox1.Text.ToString();
                Mydal objMyDal = new Mydal();
                DataTable dt = new DataTable();
                int pid = -1;
                if (TextBox10.Text == string.Empty)
                {
                    pkgerror.Visible = true;
                    pkgerror.ForeColor = System.Drawing.Color.IndianRed;
                    pkgerror.Text = "*Package ID required";
                }
                else
                {
                    pid = Convert.ToInt32(TextBox10.Text);
                    int output = objMyDal.upMemberPkg(userID, pid);
                    if (!member())
                    {
                        IDerror.Visible = true;
                        IDerror.ForeColor = System.Drawing.Color.IndianRed;
                        IDerror.Text = "*Invalid Member ID";
                    }
                    else
                    {
                        if (output == 0)
                        {
                            pkgerror.Visible = true;
                            pkgerror.ForeColor = System.Drawing.Color.IndianRed;
                            pkgerror.Text = "*Invalid Package ID";
                        }
                        else
                        {
                            member();
                            pkgerror.Visible = true;
                            pkgerror.ForeColor = System.Drawing.Color.Green;
                            pkgerror.Text = "*Updated Successfully";
                            GridView1.DataBind();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SQL error" + ex.Message.ToString());
            }
        }
        //user defined functions
        bool member()
        {
            SqlConnection con = new SqlConnection(connString);
            try
            {
                string userID = TextBox1.Text.ToString();
                Mydal objMyDal = new Mydal();
                DataTable dt = new DataTable();


                objMyDal.memberProfileLoad(userID, ref dt);

                if (dt.Rows.Count > 0)
                {
                    TextBox7.Text = dt.Rows[0]["gender"].ToString();
                    TextBox3.Text = dt.Rows[0]["name"].ToString();
                    TextBox2.Text = (Convert.ToDateTime(dt.Rows[0]["dob"]).ToString("yyyy-MM-dd"));
                    TextBox4.Text = dt.Rows[0]["email"].ToString();
                    TextBox5.Text = dt.Rows[0]["ph_no"].ToString();
                    TextBox6.Text = dt.Rows[0]["address"].ToString();
                    TextBox10.Text = dt.Rows[0]["mem_pkg_id"].ToString();
                    TextBox11.Text = dt.Rows[0]["duration"].ToString();
                    TextBox12.Text = dt.Rows[0]["bk_count"].ToString();
                    TextBox13.Text = dt.Rows[0]["amount"].ToString();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SQL error" + ex.Message.ToString());
                return false;

            }
        }
        void clear()
        {
            TextBox1.Text = string.Empty;
            TextBox3.Text = string.Empty;//name
            TextBox2.Text = string.Empty;//Date
            TextBox4.Text = string.Empty;//Email
            TextBox5.Text = string.Empty;//phno
            TextBox6.Text = string.Empty;//Address
            TextBox10.Text = string.Empty;//id
            TextBox11.Text = string.Empty;//duration
            TextBox12.Text = string.Empty;//maxbook
            TextBox13.Text = string.Empty;//ammount
        }

       
    }
}