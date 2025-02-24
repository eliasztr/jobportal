using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace jobportal.admin
{
    public partial class contactlist : System.Web.UI.Page
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
                showcontact();
            }

        }

        private void showcontact()
        {
            string query = string.Empty;
            con = new SqlConnection(str);
            query = @"Select Row_Number() over(Order by(Select 1)) as [Sr.No], contactid, name,email,message,subject from contact";
            cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {

                int contactid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                con = new SqlConnection(str);
                cmd = new SqlCommand("delete from contact where contactid=@id", con);
                cmd.Parameters.AddWithValue("@id", contactid);
                con.Open();
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    lblmsg.Text = "message deleted successfully";
                    lblmsg.CssClass = "alert alert-success";
                }
                else
                {
                    lblmsg.Text = "cannot delete this record";
                    lblmsg.CssClass = "alert alert-danger";
                }
                GridView1.EditIndex = -1;
                showcontact();


            }
            catch (Exception ex)
            {

                con.Close();
                Response.Write("<script> alert('Error: " + ex.Message + "');</script>");
                Response.Write("<p style='color:red;'>Error Details: " + ex.ToString() + "</p>");
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            showcontact();
        }
    }
}