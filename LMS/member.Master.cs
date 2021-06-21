using System;
using LMS.dal;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace LMS
{
    public partial class member : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"].Equals("member"))
                {
                    LinkButtonhello.Visible = true;
                    LinkButtonhello.Text = "Hello " + Session["fullname"].ToString();
                    
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
            Response.Redirect("member_profile.aspx");
        }
        //search book in navbar
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("member_search_books.aspx");
        }
        //borrowing history in navbar
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("member_view_books.aspx");
        }
        //logout in navbar
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
           // Session["fullname"] = "";
            Session["role"] = "";
            Response.Redirect("home.aspx");
        }

       
        //search book in footer
        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("member_search_books.aspx");
        }
        //borrowing history in footer
        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("member_view_books.aspx");
        }
        //logout in footer
        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");
        }
    }
}