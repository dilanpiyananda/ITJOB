using ITDB.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;


namespace ITCOMMON.ServiceOfHelper
{
    public static class ServiceHelper
    {
        public static string ServerPath(Section section,string userId,out string SubPath,out string virtualpathname)
        {
            if(section == Section.company)
            {
                string rootpath ="~/Company/" + userId.ToString()+"/";
                SubPath = ServiceHelper.subserverPath(userId, rootpath, out string virtualPath);
                virtualpathname = virtualPath;

                return HttpContext.Current.Server.MapPath(rootpath);
            }
            else if (section == Section.Job)
            {
                string rootpath = "~/Job/" + userId.ToString() + "/";
                SubPath = ServiceHelper.subserverPath(userId, rootpath, out string virtualPath);
                virtualpathname = virtualPath;

                return HttpContext.Current.Server.MapPath(rootpath);
            }
            else
            {
                virtualpathname = null;
                SubPath = null;
                return null;
            }
        }
        public static string FileName(Section section, FileType lastfileconcatstring)
        {
            if (section == Section.company)
            {
                string date = (DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day).ToString();
                string fileName = Section.company.ToString() + date + "_" + lastfileconcatstring.ToString();
                return fileName;
            }
            else if (section == Section.Job)
            {
                string date = (DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day).ToString();
                string fileName = Section.Job.ToString() + date + "_" + lastfileconcatstring.ToString();
                return fileName;
            }
            else
            {
                
                return null;
            }
        }
        private static string subserverPath(string userId,string root,out string virtualPath)
        {
            string source = userId + DateTime.Now.ToString();
            string hash = null;
            using (SHA1 sha1Hash = SHA1.Create())
            {
                //From String to byte array
                byte[] sourceBytes = Encoding.UTF8.GetBytes(source);
                byte[] hashBytes = sha1Hash.ComputeHash(sourceBytes);
                hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
                  
            }
            string datefolder = (DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day).ToString();
            virtualPath = (root + "/" + datefolder + "/" + hash + "/");

            return HttpContext.Current.Server.MapPath((root+"/"+ datefolder + "/" + hash+"/"));
        }
    }
}