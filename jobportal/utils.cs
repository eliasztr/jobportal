using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jobportal
{
    public class utils
    {
        public static bool IsValidExtension(string filename)
        {
            bool isvalid = false;
            string[] fileextension = { ".jpg", ".png", ".jpeg" };
            foreach (string ext in fileextension)
            {
                if (filename.ToLower().EndsWith(ext))
                {
                    isvalid = true;
                    break;
                }
            }
            return isvalid;
        }
        public static bool IsValidextensionresume(string filename)
        {
            bool isvalid = false;
            string[] fileextension = { ".doc", ".docx", ".pdf" };
            foreach (string ext in fileextension)
            {
                if (filename.ToLower().EndsWith(ext))
                {
                    isvalid = true;
                    break;
                }
            }
            return isvalid;
        }
    }
}