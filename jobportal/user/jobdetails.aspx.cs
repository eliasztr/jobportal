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
    public partial class jobdetails : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt, dt1;
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        public string jobtitle = string.Empty;
        protected void Page_init(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                showjobdetails();
                DataBind();

            }
            else
            {
                Response.Redirect("joblisting.aspx");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void showjobdetails()
        {

            con = new SqlConnection(str);
            string query = @"select * from jobs where jobid=@id";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            DataList1.DataSource = dt;
            DataList1.DataBind();
            jobtitle = dt.Rows[0]["title"].ToString();

        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "applyjob")
            {
                if (Session["user"] != null)
                {
                    try
                    {
                        con = new SqlConnection(str);
                        string query = @"insert into appliedjob values(@jobid,@userid)";
                        cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@jobid", Request.QueryString["id"]);
                        cmd.Parameters.AddWithValue("@userid", Session["userid"]);
                        con.Open();
                        int r = cmd.ExecuteNonQuery();
                        if (r > 0)
                        {
                            lblmsg.Visible = true;
                            lblmsg.Text = "job applied successfully";
                            lblmsg.CssClass = "alert alert-success";
                            showjobdetails();
                            DataList1.DataBind();
                        }
                        else
                        {
                            lblmsg.Visible = true;
                            lblmsg.Text = "job not applied ";
                            lblmsg.CssClass = "alert alert-danger";
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script> alert('" + ex.Message + "');</script>");
                    }
                    finally
                    {
                        con.Close();
                    }
                }
                else
                {
                    Response.Redirect("login.aspx");
                }
            }
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (Session["user"] != null)
            {
                LinkButton btnapply = e.Item.FindControl("lblapply") as LinkButton;
                if (btnapply != null)
                {
                    if (isapplied())
                    {
                        btnapply.Enabled = false;
                        btnapply.Text = "Applied";
                    }
                    else
                    {
                        btnapply.Enabled = true;
                        btnapply.Text = "Apply now";
                    }
                }
            }
        }

        bool isapplied()
        {
            if (Session["userid"] == null)
            {
                return false;  // User is not logged in, so they haven't applied
            }

            con = new SqlConnection(str);
            string query = @"SELECT * FROM appliedjob WHERE userid=@userid AND jobid=@jobid";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@jobid", Request.QueryString["id"]);
            cmd.Parameters.AddWithValue("@userid", Session["userid"]);

            sda = new SqlDataAdapter(cmd);
            dt1 = new DataTable();
            sda.Fill(dt1);

            return dt1.Rows.Count > 0;
        }

        protected string GetImageUrl(Object url)
        {
            string url1 = "";
            if (string.IsNullOrEmpty(url.ToString()))
            {
                url1 = "~/images/No_image.png";

            }
            else
            {
                url1 = string.Format("~/{0}", url);
            }
            return ResolveUrl(url1);
        }
    }
}