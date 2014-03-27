using System;
using System.Text.RegularExpressions;
using System.Web;

namespace YudianBlog.Infrastructure.Common
{
    public class ServerInfo
    {
        /// <summary>
        /// 虚拟应用程序根路径
        /// </summary>
        /// <returns></returns>
        public static string GetAppPath()
        {
            if (HttpContext.Current.Request.ApplicationPath == "/")
            {
                return string.Empty;
            }
            return HttpContext.Current.Request.ApplicationPath;
        }

        /// <summary>
        /// 系统的根目录
        /// </summary>
        /// <returns></returns>
        public static string GetRootPath()
        {
            string appPath = "";
            HttpContext HttpCurrent = HttpContext.Current;
            if (HttpCurrent != null)
            {
                return HttpCurrent.Server.MapPath("~");
            }
            appPath = AppDomain.CurrentDomain.BaseDirectory;
            if (Regex.Match(appPath, @"\\$", RegexOptions.Compiled).Success)
            {
                appPath = appPath.Substring(0, appPath.Length - 1);
            }
            return appPath;
        }

        /// <summary>
        /// 获取域名地址
        /// </summary>
        /// <returns></returns>
        public static string GetRootURI()
        {
            string appPath = "";
            HttpContext HttpCurrent = HttpContext.Current;
            if (HttpCurrent == null)
            {
                return appPath;
            }
            HttpRequest Req = HttpCurrent.Request;
            string UrlAuthority = Req.Url.GetLeftPart(UriPartial.Authority);
            if ((Req.ApplicationPath == null) || (Req.ApplicationPath == "/"))
            {
                return UrlAuthority;
            }
            return (UrlAuthority + Req.ApplicationPath);
        }

        /// <summary>
        /// 与应用程序元数据库路径相应的物理路径
        /// </summary>
        /// <returns></returns>
        public static string GetServerPath()
        {
            return HttpContext.Current.Request.ServerVariables["APPL_PHYSICAL_PATH"];
        }

        /// <summary>
        /// 获取版本信息
        /// </summary>
        /// <returns></returns>
        public static string VersionInformation()
        {
            Infrastructure.Common.FileHelper hf = new Infrastructure.Common.FileHelper();
            return hf.ReadFileContent(HttpContext.Current.Request.ServerVariables["APPL_PHYSICAL_PATH"] + "admin/vesion.ini").Trim();
        }
    }
}

