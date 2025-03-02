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
    public partial class joblisting : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        public int Jobcount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showjoblist();
                rbselectedcolorchange();
            }
        }

        void rbselectedcolorchange()
        {
            if (RadioButtonList1.SelectedItem.Selected == true)
            {
                RadioButtonList1.SelectedItem.Attributes.Add("class", "selectedradio");
            }
        }

        private void showjoblist()
        {
            if (dt == null)
            {
                con = new SqlConnection(str);
                string query = @"select jobid,title,salary,jobtype,companyname,companyimage,country,state,createdate from jobs";
                cmd = new SqlCommand(query, con);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
            }
            DataList1.DataSource = dt;
            DataList1.DataBind();
            lbljobCount.Text = jobcount(dt.Rows.Count);
        }
        string jobcount(int count)
        {
            if (count > 1)
            {
                return "total <b>" + count + "</b> jobs found";

            }
            else if (count == 1)
            {
                return "total <b>" + count + "</b> jobs found";
            }
            else
            {
                return "no job found";
            }
        }

        public static string RelativeDate(DateTime theDate)
        {
            Dictionary<long, string> thresholds = new Dictionary<long, string>();
            int minute = 60;
            int hour = 60 * minute;
            int day = 24 * hour;
            thresholds.Add(60, "{0} seconds ago");
            thresholds.Add(minute * 2, "a minute ago");
            thresholds.Add(45 * minute, "{0} minutes ago");
            thresholds.Add(120 * minute, "an hour ago");
            thresholds.Add(day, "{0} hours ago");
            thresholds.Add(day * 2, "yesterday");
            thresholds.Add(day * 30, "{0} days ago");
            thresholds.Add(day * 365, "{0} months ago");
            thresholds.Add(long.MaxValue, "{0} years ago");
            long since = (DateTime.Now.Ticks - theDate.Ticks) / 10000000;
            foreach (long threshold in thresholds.Keys)
            {
                if (since < threshold)
                {
                    TimeSpan t = new TimeSpan((DateTime.Now.Ticks - theDate.Ticks));
                    return string.Format(thresholds[threshold], (t.Days > 365 ? t.Days / 365 : (t.Days > 0 ? t.Days : (t.Hours > 0 ? t.Hours : (t.Minutes > 0 ? t.Minutes : (t.Seconds > 0 ? t.Seconds : 0))))).ToString());
                }
            }
            return "";
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

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCountry.SelectedIndex != 0)
            {
                con = new SqlConnection(str);
                string query = @"select jobid,title,salary,jobtype,companyname,companyimage,country,state,createdate from jobs where country='" + ddlCountry.SelectedValue + "'";
                cmd = new SqlCommand(query, con);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                showjoblist();
                rbselectedcolorchange();


            }
            else
            {
                showjoblist();
                rbselectedcolorchange();
            }
        }

        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string jobtype = string.Empty;
            jobtype = Selectedcheckbox();
            if (jobtype != "")
            {
                con = new SqlConnection(str);
                string query = @"select jobid,title,salary,jobtype,companyname,companyimage,country,state,createdate from jobs where jobtype IN(" + jobtype + ")";
                cmd = new SqlCommand(query, con);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                showjoblist();
                rbselectedcolorchange();
            }
        }
        string Selectedcheckbox()
        {
            string jobtype = string.Empty;
            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected)
                {
                    jobtype += "'" + CheckBoxList1.Items[i].Text + "',";
                }
            }
            return jobtype.TrimEnd(',');
        }


        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedValue != "0")
            {
                string posteddate = Selectedradiobutton();

                con = new SqlConnection(str);
                string query = @"SELECT jobid, title, salary, jobtype, companyname, companyimage, country, state, createdate 
                         FROM jobs 
                         WHERE CONVERT(DATE, createdate) " + posteddate;

                cmd = new SqlCommand(query, con);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                showjoblist();
                rbselectedcolorchange();
            }
            else
            {
                showjoblist();
                rbselectedcolorchange();
            }
        }


        string Selectedradiobutton()
        {
            string posteddate = string.Empty;
            DateTime date = DateTime.Today;

            if (RadioButtonList1.SelectedValue == "1")
            {
                posteddate = "= CONVERT(DATE, '" + date.ToString("yyyy-MM-dd") + "')";
            }
            else if (RadioButtonList1.SelectedValue == "2")
            {
                posteddate = "BETWEEN CONVERT(DATE, '" + DateTime.Now.AddDays(-2).ToString("yyyy-MM-dd") + "') AND CONVERT(DATE, '" + date.ToString("yyyy-MM-dd") + "')";
            }
            else if (RadioButtonList1.SelectedValue == "3")
            {
                posteddate = "BETWEEN CONVERT(DATE, '" + DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd") + "') AND CONVERT(DATE, '" + date.ToString("yyyy-MM-dd") + "')";
            }
            else if (RadioButtonList1.SelectedValue == "4")
            {
                posteddate = "BETWEEN CONVERT(DATE, '" + DateTime.Now.AddDays(-5).ToString("yyyy-MM-dd") + "') AND CONVERT(DATE, '" + date.ToString("yyyy-MM-dd") + "')";
            }
            else
            {
                posteddate = "BETWEEN CONVERT(DATE, '" + DateTime.Now.AddDays(-10).ToString("yyyy-MM-dd") + "') AND CONVERT(DATE, '" + date.ToString("yyyy-MM-dd") + "')";
            }

            return posteddate;
        }


        protected void lbFilter_Click(object sender, EventArgs e)
        {
            bool iscondition = false;
            string subquery = string.Empty;
            string jobtype = string.Empty;
            string posteddate = string.Empty;
            string query = string.Empty;
            List<string> querylist = new List<string>();
            con = new SqlConnection(str);
            if (ddlCountry.SelectedValue != "0")
            {
                querylist.Add("country='" + ddlCountry.SelectedValue + "'");
                iscondition = true;
            }
            jobtype = Selectedcheckbox();
            if (jobtype != "")
            {
                querylist.Add("jobtype IN(" + jobtype + ")");
                iscondition = true;
            }
            if (RadioButtonList1.SelectedValue != "0")
            {
                posteddate = Selectedradiobutton();
                querylist.Add("Convert(DATE,createdate)" + posteddate);
                iscondition = true;
            }
            if (iscondition)
            {
                foreach (string a in querylist)
                {
                    subquery += a + " and ";
                }
                subquery = subquery.Remove(subquery.LastIndexOf("and"), 3);
                query = @"SELECT jobid, title, salary, jobtype, companyname, companyimage, country, state, createdate 
                         FROM jobs 
                         WHERE  " + subquery + " ";
            }
        }

        protected void lbReset_Click(object sender, EventArgs e)
        {

            ddlCountry.SelectedIndex = 0;


            foreach (ListItem item in CheckBoxList1.Items)
            {
                item.Selected = false;
            }

            // Reset Radio Button List
            RadioButtonList1.ClearSelection();

            // Reset DataTable
            dt = null;

            // Reload Full Job List
            showjoblist();

            rbselectedcolorchange();
        }

    }
}