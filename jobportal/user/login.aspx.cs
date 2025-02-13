using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace jobportal.user
{
    public partial class login : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        string username, password = string.Empty;
        SqlDataReader sdr;


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddllogintype.SelectedValue == "Admin")
                {
                    username = ConfigurationManager.AppSettings["username"];
                    password = ConfigurationManager.AppSettings["password"];

                    if (username == txtusername.Text.Trim() && password == txtpassword.Text.Trim())
                    {
                        Session["admin"] = username;
                        Response.Redirect("../admin/dashboard.aspx", false);
                    }
                    else
                    {
                        ShowErrorMsg("Admin");
                    }
                }
                else
                {
                    using (con = new SqlConnection(str))
                    {
                        string query = "SELECT username, userID, password FROM [user] WHERE username = @username";
                        cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@username", txtusername.Text.Trim());

                        con.Open();
                        sdr = cmd.ExecuteReader();

                        if (sdr.Read())
                        {
                            string storedHashedPassword = sdr["password"].ToString();
                            string enteredPassword = txtpassword.Text.Trim();

                            if (!string.IsNullOrEmpty(storedHashedPassword) && storedHashedPassword.StartsWith("$2"))
                            {
                                if (BCrypt.Net.BCrypt.Verify(enteredPassword, storedHashedPassword))
                                {
                                    Session["user"] = sdr["username"].ToString();
                                    Session["userID"] = sdr["userID"].ToString();
                                    Response.Redirect("Default.aspx", false);
                                }
                                else
                                {
                                    ShowErrorMsg("User");
                                }
                            }
                            else
                            {
                                ShowErrorMsg("User");
                            }
                        }
                        else
                        {
                            ShowErrorMsg("User");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "');</script>");
            }
        }



        private void ShowErrorMsg(string usertype)
        {
            lblmsg.Visible = true;
            lblmsg.Text = "<b>" + usertype + "</b> credentials are incorrect ";
            lblmsg.CssClass = "alert alert-danger";

        }
    }
}