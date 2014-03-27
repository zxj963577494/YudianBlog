using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YudianBlog.Services.ViewModel
{
    /// <summary>
    /// 作者详细信息视图
    /// </summary>
    public class UserDetailView
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public int User_id
        {
            get;
            set;
        }

        /// <summary>
        /// 用户电邮地址
        /// </summary>
        public string User_email
        {
            get;
            set;
        }

        /// <summary>
        /// 用户昵称
        /// </summary>
        public string User_nicename
        {
            get;
            set;
        }

        /// <summary>
        /// 用户的注册名称
        /// </summary>
        public string User_login
        {
            get;
            set;
        }

        /// <summary>
        /// 用户注册时间
        /// </summary>
        public DateTime User_registeredtime
        {
            get;
            set;
        }

        /// <summary>
        /// 用户状态
        /// </summary>
        public int User_status
        {
            get;
            set;
        }

        /// <summary>
        /// 用户网址
        /// </summary>
        public string User_url
        {
            get;
            set;
        }

        /// <summary>
        /// 作者额外信息视图
        /// </summary>
        public IEnumerable<UserMetaView> UserMetaInfo
        {
            get; 
            set;
        }
    }
}
