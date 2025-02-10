using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace jobportal.user
{
    public partial class contact : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsend_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(str);
                string query = "INSERT INTO contact (name, email, subject, message) VALUES (@name, @email, @subject, @message)";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@subject", txtSubject.Text.Trim());
                cmd.Parameters.AddWithValue("@message", txtMessage.Text.Trim());

                con.Open();
                int r = cmd.ExecuteNonQuery();

                if (r > 0)
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "Thanks for reaching out! We will look into your query.";
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
            catch (Exception ex)
            {
                lblmsg.Visible = true;
                lblmsg.Text = "Error: " + ex.Message;
                lblmsg.CssClass = "alert alert-danger";
            }
            finally
            {
                con.Close();
            }
        }

        private void Clear()
        {
            txtName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtSubject.Text = string.Empty;
            txtMessage.Text = string.Empty;
        }
    }
}