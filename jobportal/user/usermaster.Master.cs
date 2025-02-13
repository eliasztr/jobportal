using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace jobportal.user
{
    public partial class usermaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                lbregisterorprofile.Text = "profile";
                lbloginorlogout.Text = "logout";

            }
            else
            {
                lbregisterorprofile.Text = "register";
                lbloginorlogout.Text = "login";
            }
        }

        protected void lbregisterorprofile_Click(object sender, EventArgs e)
        {
            if (lbregisterorprofile.Text == "profile")
            {
                Response.Redirect("profile.aspx");
            }
            else
            {
                Response.Redirect("register.aspx");
            }
        }

        protected void lbloginorlogout_Click(object sender, EventArgs e)
        {
            if (lbloginorlogout.Text == "login")
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                Session.Abandon();
                Response.Redirect("login.aspx");
            }
        }
    }
}