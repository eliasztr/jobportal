using System;
using System.IO;
using System.Web;

namespace jobportal
{
    public class DownloadResume : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string filename = HttpContext.Current.Server.UrlDecode(context.Request.QueryString["file"]);

            context.Response.Write("Received filename from query string: " + filename);  // Debugging line

            if (string.IsNullOrEmpty(filename))
            {
                context.Response.StatusCode = 400;
                context.Response.Write("Invalid file request.");
                return;
            }

            filename = filename.Replace("resume/", "").Trim();

            context.Response.Write("Cleaned filename: " + filename);

            string folderPath = HttpContext.Current.Server.MapPath("~/resume/");

            string filePath = Path.Combine(folderPath, filename);

            context.Response.Write("File Path: " + filePath);

            if (!File.Exists(filePath))
            {
                context.Response.StatusCode = 404;
                context.Response.Write("File not found: " + filePath);
                return;
            }

            context.Response.ContentType = "application/octet-stream";
            context.Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);

            context.Response.TransmitFile(filePath);
            context.Response.End();
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}
