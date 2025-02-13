using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using BCrypt.Net;



namespace jobportal.user
{
    
    public partial class register : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnregister_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(str);
                string query = "INSERT INTO [user] (username,password,name,email,mobile,address,country) VALUES (@username,@password,@name,@email,@mobile,@address,@country)";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", txtusername.Text.Trim());

                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(txtconfirmpassword.Text.Trim());
                cmd.Parameters.AddWithValue("@password", hashedPassword);

                cmd.Parameters.AddWithValue("@name", txtfullname.Text.Trim());
                cmd.Parameters.AddWithValue("@email", txtemail.Text.Trim());
                cmd.Parameters.AddWithValue("@mobile", txtmobile.Text.Trim());
                cmd.Parameters.AddWithValue("@address", txtaddress.Text.Trim());
                cmd.Parameters.AddWithValue("@country", ddlcountry.SelectedValue);

                con.Open();
                int r = cmd.ExecuteNonQuery();

                if (r > 0)
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "Registered successfully";
                    lblmsg.CssClass = "alert alert-success";
                    Clear();
                }
                else
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "Cannot save record right now, please try again later.";
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
                Response.Write("<script> alert('" + ex.Message + "');</script>");
            }
            finally
            {
                con.Close();
            }
        }

        private void Clear()
        {
            txtaddress.Text= string.Empty;  
            txtconfirmpassword.Text= string.Empty;
            txtfullname.Text= string.Empty;
            txtmobile.Text= string.Empty;
            txtemail.Text= string.Empty;
            txtmobile.Text = string.Empty;
            txtusername.Text= string.Empty;
            ddlcountry.ClearSelection();




        }
    }
}