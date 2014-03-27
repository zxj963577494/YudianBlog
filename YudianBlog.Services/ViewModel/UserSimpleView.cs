using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YudianBlog.Services.ViewModel
{
    /// <summary>
    /// 作者简单视图
    /// </summary>
    public class UserSimpleView
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public virtual int User_id
        {
            get;
            set;
        }

        /// <summary>
        /// 用户昵称
        /// </summary>
        public virtual string User_nicename
        {
            get;
            set;
        }
    }
}
