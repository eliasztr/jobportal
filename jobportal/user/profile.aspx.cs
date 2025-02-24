using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace jobportal.user
{

    public partial class profile : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;

        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("login.aspx");
            }
            if (!IsPostBack)
            {
                showUserprofile();
            }
        }

        private void showUserprofile()
        {
            con = new SqlConnection(str);
            string query = "select userid,username,name,address,mobile,email,country,resume from [user] where username=@username";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", Session["user"]);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                dlprofile.DataSource = dt;
                dlprofile.DataBind();
            }
            else
            {
                Response.Write("<script> alert('please do login with your latest username  ');</script>");
            }
        }

        protected void dlprofile_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "edituserprofile")
            {
                Response.Redirect("resumebuild.aspx?id=" + e.CommandArgument.ToString());
            }
        }
    }
}