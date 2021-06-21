using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS
{
    public partial class admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"].Equals("admin"))
                {
                    LinkButtonhello.Visible = true;
                    LinkButtonhello.Text = "Hello Admin " + Session["username"].ToString();
                }
                else
                {
                    LinkButtonhello.Visible = false;
                }
            }
            catch (Exception ex)
            {

            }
        }
        //profile in navbar
        protected void LinkButtonhello_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin_profile.aspx");
        }
        //author management in navbar
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin_author_management.aspx");
        }
        //publisher management in navbar
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin_publisher_management.aspx");
        }
        //book inventory in navbar
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin_book_inventory.aspx");
        }
        //book issuing in navbar
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin_book_issuing.aspx");
        }
        //member management in navbar
        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin_member_management.aspx");
        }
        //logout in navbar
        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            // Session["fullname"] = "";
            Session["role"] = "";
            Response.Redirect("home.aspx");
        }

        
        
        //author management in footer
        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin_author_management.aspx");
        }
        //publisher management in footer
        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin_publisher_management.aspx");
        }
        //book inventory in footer
        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin_book_inventory.aspx");
        }
        //book issuing in footer
        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin_book_issuing.aspx");
        }
        //member management in footer
        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin_member_management.aspx");
        }
        //logout in footer
        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            // Session["fullname"] = "";
            Session["role"] = "";
            Response.Redirect("home.aspx");
        }
    }
}