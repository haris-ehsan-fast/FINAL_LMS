using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMS.dal;
using System.Data.SqlClient;
using System.Data;

namespace LMS
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        private static readonly string connString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                try
                {
                    
                    if (Session["username"].ToString() == "" || Session["username"] == null)
                    {
                        Response.Write("<script>alert('Session Expired Login Again');</script>");
                        Response.Redirect("userlogin.aspx");
                    }
                    else
                    {
                        GridView1.DataBind();
                        loadReviews();
                    }
                }
                catch (Exception ex)
                {

                    Response.Write("<script>alert('Session Expired Login Again');</script>");
                    Response.Redirect("member_login.aspx");
                }
            }
        }
        //submit review button
        protected void Button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            string bID = gvr.Cells[0].Text.ToString();
            string memberID = Session["username"].ToString();
            string rev = ((TextBox)GridView1.Rows[gvr.RowIndex].FindControl("TextBox5")).Text.ToString();
            Mydal objMyDal = new Mydal();
            objMyDal.addReview(memberID, bID, rev);
        }
        //checking expected return date
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[3].Text);
                    DateTime today = DateTime.Today;
                    if (today > dt && e.Row.Cells[4].Text == "&nbsp;")
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
        //user defined functions
        void loadReviews()
        {
            Mydal objMyDal = new Mydal();
            string mID = Session["username"].ToString();
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                string bID = GridView1.Rows[i].Cells[0].Text.ToString();
                DataTable DT = new DataTable();
                objMyDal.issueLoad(mID, bID, ref DT);
                ((TextBox)GridView1.Rows[i].FindControl("TextBox5")).Text = DT.Rows[0][5].ToString();           
            }
            
        }
    }
}