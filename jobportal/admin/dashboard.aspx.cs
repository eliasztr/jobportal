using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace jobportal.admin
{

    public partial class dashboard : System.Web.UI.Page
    {
        SqlConnection con;
        SqlDataAdapter sda;
        DataTable dt;
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("../user/login.aspx");
            }
            if (!IsPostBack)
            {
                users();
                Jobs();
                AppliedJobs();
                ContactCount();
                DataBind();
            }
        }

        private void AppliedJobs()
        {
            con = new SqlConnection(str);
            sda = new SqlDataAdapter("select Count(*) from appliedjob", con);
            dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["appliedjob"] = dt.Rows[0][0];

            }
            else
            {
                Session["appliedjob"] = 0;
            }
        }

        private void ContactCount()
        {
            con = new SqlConnection(str);
            sda = new SqlDataAdapter("select Count(*) from contact", con);
            dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["contact"] = dt.Rows[0][0];

            }
            else
            {
                Session["contact"] = 0;
            }
        }

        private void Jobs()
        {
            con = new SqlConnection(str);
            sda = new SqlDataAdapter("select Count(*) from jobs", con);
            dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["jobs"] = dt.Rows[0][0];

            }
            else
            {
                Session["jobs"] = 0;
            }
        }

        private void users()
        {
            con = new SqlConnection(str);
            sda = new SqlDataAdapter("select Count(*) from [user]", con);
            dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["users"] = dt.Rows[0][0];

            }
            else
            {
                Session["users"] = 0;
            }
        }
    }
}