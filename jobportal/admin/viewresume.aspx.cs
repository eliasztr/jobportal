using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace jobportal.admin
{
    public partial class viewresume : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        DataTable dt;
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
            {
                Response.Redirect("../user/login.aspx");
            }
            if (!IsPostBack)
            {
                showappliedjob();
            }
        }
        private void showappliedjob()
        {
            string query = string.Empty;
            con = new SqlConnection(str);
            query = @"select row_number() over(order by (select 1)) as [Sr.No],aj.appliedjob,j.companyname,aj.jobid, j.title,u.mobile,u.name,u.email,u.resume from appliedjob aj 
             inner join [user] u on aj.userid=u.userid
             inner join jobs j on aj.jobid=j.jobid";
            cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            showappliedjob();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
            e.Row.ToolTip = "Click to view job details";
        }



    }
}