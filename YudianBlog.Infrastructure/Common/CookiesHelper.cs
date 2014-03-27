using System;
using System.Collections.Generic;
using System.Web;

namespace YudianBlog.Infrastructure.Common
{
    /// <summary>
    /// 功能：cookies 操作
    /// </summary>
    public class CookiesHelper
    {

        #region 获取Cookie
        /// <summary>
        /// 获得Cookie的值
        /// </summary>
        /// <param name="cookieName"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetCookieValue(string cookieName, string key)
        {
            HttpRequest request = HttpContext.Current.Request;
            if (request != null)
                return GetCookieValue(request.Cookies[cookieName], key);
            return "";
        }
        /// <summary>
        /// 获得Cookie的子键值
        /// </summary>
        /// <param name="cookie"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetCookieValue(HttpCookie cookie, string key)
        {
            if (cookie != null)
            {
                if (!string.IsNullOrEmpty(key) && cookie.HasKeys)
                    return cookie.Values[key];
                else
                    return cookie.Value;
            }
            return "";
        }

        /// <summary>
        /// 读cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <returns>cookie值</returns>
        public static string GetCookie(string strName)
        {
            if (HttpContext.Current != null && HttpContext.Current.Request != null)
            {
                if (HttpContext.Current.Request.Cookies[strName] != null)
                {
                    return HttpContext.Current.Request.Cookies[strName].Value.ToString();
                }

            }

            return "";
        }



        #endregion

        #region 设置/修改Cookie

        #region //设置Cookie子键的值 SetCookie(string cookieName, string key, string value)
        /// <summary>
        /// 功能：设置Cookie子键的值
        /// 添加人：王
        /// 添加时间：2013-07-15
        /// </summary>
        /// <param name="cookieName"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetCookie(string cookieName, string key, string value, DateTime expires)
        {
            SetCookies(cookieName, key, value, expires);
        }
        #endregion

        #region // 设置Cookie SetCookie(string cookieName, string key, string value, DateTime? expires)
        /// <summary>
        /// 功能： 设置Cookie
        /// 添加人：王
        /// 添加时间：2013-07-15
        /// </summary>
        /// <param name="cookieName"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expires"></param>
        public static void SetCookies(string cookieName, string key, string value, DateTime expires)
        {
            HttpCookie cook = HttpContext.Current.Request.Cookies[cookieName];
            if (cook != null)
            {
                if (!string.IsNullOrEmpty(key) && cook.HasKeys)
                    cook.Values[key] = value;
                else
                    if (!string.IsNullOrEmpty(value))
                        cook.Value = value;
                cook.Expires = expires;
                HttpContext.Current.Response.SetCookie(cook);
            }
        }
        #endregion

        #endregion

        #region 添加Cookie

        #region //添加Cookie AddCookie(string key, string value, DateTime expires)
        /// <summary>
        /// 功能：添加Cookie
        /// 添加人：王
        /// 添加时间：2013-07-15
        /// </summary>
        /// <param name="key">CookiesName</param>
        /// <param name="value">Cookies值</param>
        /// <param name="expires">过期时间</param>
        public static void AddCookie(string key, string value, DateTime expires)
        {
            HttpCookie cookie = new HttpCookie(key, value);
            cookie.Expires = expires;
            AddCookie(cookie);
        }
        #endregion

        #region // 添加为Cookie.Values含子键集合 AddCookie(string cookieName,List<string[]> list, DateTime expires)
        /// <summary>
        /// 功能： 添加为Cookie.Values含子键集合
        /// 添加人：王
        /// 添加时间：2013-07-15
        /// </summary>
        /// <param name="cookieName">cookieName</param>
        /// <param name="list">子键集合</param>
        /// <param name="expires">过期时间</param>
        public static void AddCookie(string cookieName, List<string[]> list, DateTime expires)
        {
            HttpCookie cookie = new HttpCookie(cookieName);

            foreach (string[] item in list)
            {
                cookie.Values.Add(item[0], item[1]);
            }
            cookie.Expires = expires;
            AddCookie(cookie);
        }
        #endregion


        #region // 添加为Cookie.Values含子键 AddCookie(string cookieName, string keys,string velue, DateTime expires)
        /// <summary>
        /// 功能： 添加为Cookie.Values含子键
        /// 添加人：王
        /// 添加时间：2013-07-15
        /// </summary>
        /// <param name="cookieName">cookieName</param>
        /// <param name="keys">子键集合</param>
        /// <param name="velue">子键集合</param>
        /// <param name="expires">过期时间</param>
        public static void AddCookie(string cookieName, string keys, string velue, DateTime expires)
        {
            HttpCookie cookie = new HttpCookie(cookieName);
            cookie.Values.Add(keys, velue);
            AddCookie(cookie);
        }
        #endregion

        #region  //添加Cookie  AddCookie(HttpCookie cookie)
        /// <summary>
        /// 添加Cookie
        /// </summary>
        /// <param name="cookie"></param>
        public static void AddCookie(HttpCookie cookie)
        {
            HttpResponse response = HttpContext.Current.Response;
            if (response != null)
            {
                //指定客户端脚本是否可以访问[默认为false]
                cookie.HttpOnly = false;
                //指定统一的Path，比便能通存通取
                cookie.Path = "/";
                response.AppendCookie(cookie);
            }
        }
        #endregion

        #region 写cookie值

        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        public static void WriteCookie(string strName, string strValue)
        {
            if (HttpContext.Current != null)
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
                if (cookie == null)
                {
                    cookie = new HttpCookie(strName);
                }
                cookie.Value = strValue;
                HttpContext.Current.Response.AppendCookie(cookie);

            }

        }
        #endregion

        #endregion
    }
}
