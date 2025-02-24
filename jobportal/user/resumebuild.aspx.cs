using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq.Expressions;
using System.Web.DynamicData;

namespace jobportal.user
{
    public partial class resumebuild : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader sdr;
        string query;
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("login.aspx");
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    showuserinfo();
                }
                else
                {
                    Response.Redirect("login.aspx");
                }
            }

        }

        private void showuserinfo()
        {
            try
            {
                con = new SqlConnection(str);
                string query = "select * from [user] where userid=@id";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
                con.Open();
                sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    if (sdr.Read())
                    {
                        txtusername.Text = sdr["username"].ToString();
                        txtfullname.Text = sdr["name"].ToString();
                        txtemail.Text = sdr["email"].ToString();
                        txtmobile.Text = sdr["mobile"].ToString();
                        txttwelfth.Text = sdr["twelfthgrade"].ToString();
                        txttenth.Text = sdr["tenthgrade"].ToString();
                        txtgraduation.Text = sdr["graduationgrade"].ToString();
                        txtpostgrad.Text = sdr["postgraduationgrade"].ToString();
                        txtphd.Text = sdr["phd"].ToString();
                        txtwork.Text = sdr["workson"].ToString();
                        txtexperience.Text = sdr["experience"].ToString();
                        txtaddress.Text = sdr["address"].ToString();
                        ddlcountry.SelectedValue = sdr["country"].ToString();
                    }
                }
                else
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "user not found";
                    lblmsg.CssClass = "alert alert-danger";
                }

            }
            catch (Exception ex)
            {

                Response.Write("<script> alert('Error: " + ex.Message + "');</script>");
                Response.Write("<p style='color:red;'>Error Details: " + ex.ToString() + "</p>");
            }
            finally
            {
                con.Close();
            }
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["id"] != null)
                {
                    string concatquery = string.Empty;
                    string filepath = string.Empty;
                    //bool isvalidtoexecute=false;
                    bool isvalid = false;
                    con = new SqlConnection(str);
                    if (furesume.HasFile)
                    {
                        if (utils.IsValidextensionresume(furesume.FileName))
                        {
                            concatquery = "resume=@resume";
                            isvalid = true;
                        }
                        else
                        {
                            //concatquery = string.Empty;
                            lblmsg.Visible = true;
                            lblmsg.Text = "please select .doc,.docx ,.pdf";
                            lblmsg.CssClass = "alert alert-danger";
                        }
                    }
                    else
                    {
                        concatquery = string.Empty;
                    }
                    query = @"update [user] set username=@username,name=@name ,email=@email,mobile=@mobile,tenthgrade=@tenthgrade,twelfthgrade=@twelfthgrade,graduationgrade=@graduationgrade,postgraduationgrade=@postgraduationgrade,phd=@phd,workson=@workson,experience=@experience," + concatquery + ",address=@address,country=@country where userid=@id";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@username", txtusername.Text.Trim());
                    cmd.Parameters.AddWithValue("@name", txtfullname.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", txtemail.Text.Trim());
                    cmd.Parameters.AddWithValue("@mobile", txtmobile.Text.Trim());
                    cmd.Parameters.AddWithValue("@tenthgrade", txttenth.Text.Trim());
                    cmd.Parameters.AddWithValue("@twelfthgrade", txttwelfth.Text.Trim());
                    cmd.Parameters.AddWithValue("@graduationgrade", txtgraduation.Text.Trim());
                    cmd.Parameters.AddWithValue("@postgraduationgrade", txtpostgrad.Text.Trim());
                    cmd.Parameters.AddWithValue("@phd", txtphd.Text.Trim());
                    cmd.Parameters.AddWithValue("@workson", txtwork.Text.Trim());
                    cmd.Parameters.AddWithValue("@experience", txtexperience.Text.Trim());
                    cmd.Parameters.AddWithValue("@address", txtaddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@country", ddlcountry.SelectedValue);
                    cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
                    if (isvalid)
                    {
                        Guid obj = Guid.NewGuid();
                        filepath = "resume/ " + obj.ToString() + furesume.FileName;
                        furesume.PostedFile.SaveAs(Server.MapPath("~/resume/") + obj.ToString() + furesume.FileName);
                        cmd.Parameters.AddWithValue("@resume", filepath);
                        //isvalidtoexecute = true;

                    }
                    else
                    {
                        isvalid = true;
                    }
                    if (isvalid)
                    {
                        con.Open();
                        int r = cmd.ExecuteNonQuery();
                        if (r > 0)
                        {
                            lblmsg.Visible = true;
                            lblmsg.Text = "resume details updated successfully";
                            lblmsg.CssClass = "alert alert-success";
                        }
                        else
                        {
                            lblmsg.Visible = true;
                            lblmsg.Text = "cannot update the records please try again later";
                            lblmsg.CssClass = "alert alert-danger";
                        }
                    }


                }
                else
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "cannot update the records";
                    lblmsg.CssClass = "alert alert-danger";
                }
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("Violation of UNIQUE KEY constraint"))
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "<b>" + txtusername.Text.Trim() + "</b> Username already exists";
                    lblmsg.CssClass = "alert alert-danger";
                }
                else
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "SQL Error: " + ex.Message;
                    lblmsg.CssClass = "alert alert-danger";
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('Error: " + ex.Message + "');</script>");
                Response.Write("<p style='color:red;'>Error Details: " + ex.ToString() + "</p>");
            }
            finally
            {
                con.Close();
            }
        }
    }
}