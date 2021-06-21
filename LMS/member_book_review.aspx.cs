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
    public partial class WebForm15 : System.Web.UI.Page
    {
        private static readonly string connString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            string bID = Request.QueryString["book_id"];
            SqlConnection con = new SqlConnection(connString);
            Mydal objMyDal = new Mydal();
            DataTable dt = new DataTable();
            objMyDal.bookReviewLoad(bID, ref dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}