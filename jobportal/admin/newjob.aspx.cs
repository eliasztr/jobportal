using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace jobportal.admin
{
    public partial class newjob : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        string query;
        string imagepath = string.Empty;
        bool isvalidtoexecute = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
            {
                Response.Redirect("../user/login.aspx");
            }
            Session["title"] = "Add Job";
            if (!IsPostBack)
            {
                FillData();
            }
        }

        private void FillData()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                using (con = new SqlConnection(str))
                {
                    query = "SELECT * FROM jobs WHERE jobid=@id";
                    using (cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            if (sdr.Read())
                            {
                                txtjobtitle.Text = sdr["title"].ToString();
                                txtnumofposts.Text = sdr["numofpost"].ToString();
                                txtdescription.Text = sdr["description"].ToString();
                                txtexperience.Text = sdr["experience"].ToString();
                                txtspecialization.Text = sdr["specialization"].ToString();
                                txtlastdate.Text = Convert.ToDateTime(sdr["lastdatetoapply"]).ToString("yyyy-MM-dd");
                                txtsalary.Text = sdr["salary"].ToString();
                                ddljobtype.SelectedValue = sdr["jobtype"].ToString();
                                txtcompany.Text = sdr["companyname"].ToString();
                                txtwebsite.Text = sdr["website"].ToString();
                                txtemail.Text = sdr["email"].ToString();
                                txtaddress.Text = sdr["address"].ToString();
                                ddlcountry.SelectedValue = sdr["country"].ToString();
                                txtstate.Text = sdr["state"].ToString();

                                btnaddjob.Text = "Update";
                                linkback.Visible = true;
                                Session["title"] = "Edit Job";
                            }
                            else
                            {
                                lblmsg.Text = "Job not found.";
                                lblmsg.CssClass = "alert alert-danger";
                            }
                        }
                    }
                }
            }
        }

        protected void btnaddjob_Click(object sender, EventArgs e)
        {
            try
            {
                string type, query, imagepath = string.Empty;
                bool isvalidtoexecute = false;

                using (con = new SqlConnection(str))
                {
                    if (Request.QueryString["id"] != null)
                    {
                        // Update case
                        string concatquery = string.Empty;
                        if (fucompanylogo.HasFile)
                        {
                            if (utils.IsValidExtension(fucompanylogo.FileName))
                            {
                                concatquery = ", companyimage=@companyimage";
                                Guid obj = Guid.NewGuid();
                                imagepath = "images/" + obj.ToString() + fucompanylogo.FileName;
                                fucompanylogo.PostedFile.SaveAs(Server.MapPath("~/images/") + obj.ToString() + fucompanylogo.FileName);
                            }
                            else
                            {
                                lblmsg.Text = "Please select .jpg, .jpeg, or .png file for logo.";
                                lblmsg.CssClass = "alert alert-danger";
                                return;
                            }
                        }

                        query = $@"UPDATE jobs 
                                   SET title=@title, 
                                       numofpost=@numofpost, 
                                       description=@description, 
                                       qualification=@qualification, 
                                       experience=@experience, 
                                       specialization=@specialization, 
                                       lastdatetoapply=@lastdatetoapply, 
                                       salary=@salary, 
                                       jobtype=@jobtype, 
                                       companyname=@companyname 
                                       {concatquery}, 
                                       website=@website, 
                                       email=@email, 
                                       address=@address, 
                                       country=@country, 
                                       state=@state 
                                   WHERE jobid=@id";
                        type = "updated";
                        isvalidtoexecute = true;
                    }
                    else
                    {
                        // Insert case
                        query = @"INSERT INTO jobs 
                                  (title, numofpost, description, qualification, experience, specialization, 
                                   lastdatetoapply, salary, jobtype, companyname, companyimage, website, 
                                   email, address, country, state, createdate) 
                                  VALUES 
                                  (@title, @numofpost, @description, @qualification, @experience, @specialization, 
                                   @lastdatetoapply, @salary, @jobtype, @companyname, @companyimage, @website, 
                                   @email, @address, @country, @state, @createdate)";
                        type = "saved";

                        // Check for file upload for insert
                        if (fucompanylogo.HasFile)
                        {
                            if (utils.IsValidExtension(fucompanylogo.FileName))
                            {
                                Guid obj = Guid.NewGuid();
                                imagepath = "images/" + obj.ToString() + fucompanylogo.FileName;
                                fucompanylogo.PostedFile.SaveAs(Server.MapPath("~/images/") + obj.ToString() + fucompanylogo.FileName);
                                isvalidtoexecute = true;
                            }
                            else
                            {
                                lblmsg.Text = "Please select .jpg, .jpeg, or .png file for logo.";
                                lblmsg.CssClass = "alert alert-danger";
                                return;
                            }
                        }
                        else
                        {
                            // Allow insert without image
                            imagepath = string.Empty;
                            isvalidtoexecute = true;
                        }
                    }

                    if (isvalidtoexecute)
                    {
                        cmd = new SqlCommand(query, con);

                        // Add common parameters
                        cmd.Parameters.AddWithValue("@title", txtjobtitle.Text.Trim());
                        cmd.Parameters.AddWithValue("@numofpost", txtnumofposts.Text.Trim());
                        cmd.Parameters.AddWithValue("@description", txtdescription.Text.Trim());
                        cmd.Parameters.AddWithValue("@qualification", txtqualification.Text.Trim());
                        cmd.Parameters.AddWithValue("@experience", txtexperience.Text.Trim());
                        cmd.Parameters.AddWithValue("@specialization", txtspecialization.Text.Trim());
                        cmd.Parameters.AddWithValue("@lastdatetoapply", DateTime.Parse(txtlastdate.Text.Trim()));
                        cmd.Parameters.AddWithValue("@salary", txtsalary.Text.Trim());
                        cmd.Parameters.AddWithValue("@jobtype", ddljobtype.SelectedValue);
                        cmd.Parameters.AddWithValue("@companyname", txtcompany.Text.Trim());
                        cmd.Parameters.AddWithValue("@website", txtwebsite.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", txtemail.Text.Trim());
                        cmd.Parameters.AddWithValue("@address", txtaddress.Text.Trim());
                        cmd.Parameters.AddWithValue("@country", ddlcountry.SelectedValue);
                        cmd.Parameters.AddWithValue("@state", txtstate.Text.Trim());

                        // Handle specific parameters
                        if (Request.QueryString["id"] != null)
                        {
                            // Update: add companyimage if needed and @id
                            if (!string.IsNullOrEmpty(imagepath))
                            {
                                cmd.Parameters.AddWithValue("@companyimage", imagepath);
                            }
                            cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
                        }
                        else
                        {
                            // Insert: add createdate and companyimage
                            cmd.Parameters.AddWithValue("@createdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            cmd.Parameters.AddWithValue("@companyimage", imagepath);
                        }

                        con.Open();
                        int res = cmd.ExecuteNonQuery();
                        if (res > 0)
                        {
                            lblmsg.Text = "Job " + type + " successfully.";
                            lblmsg.CssClass = "alert alert-success";
                            Clear();
                        }
                        else
                        {
                            lblmsg.Text = "Cannot " + type + " the job. Please try again later.";
                            lblmsg.CssClass = "alert alert-danger";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }

        private void Clear()
        {
            txtaddress.Text = string.Empty;
            txtcompany.Text = string.Empty;
            txtdescription.Text = string.Empty;
            txtemail.Text = string.Empty;
            txtexperience.Text = string.Empty;
            txtjobtitle.Text = string.Empty;
            txtlastdate.Text = string.Empty;
            txtnumofposts.Text = string.Empty;
            txtqualification.Text = string.Empty;
            txtsalary.Text = string.Empty;
            txtspecialization.Text = string.Empty;
            txtstate.Text = string.Empty;
            txtwebsite.Text = string.Empty;
            ddljobtype.ClearSelection();
            ddlcountry.ClearSelection();
        }


    }
}