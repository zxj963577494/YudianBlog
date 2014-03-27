using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YudianBlog.Services.ViewModel
{
    /// <summary>
    /// 作者额外信息视图
    /// </summary>
    public class UserMetaView
    {
        /// <summary>
        /// UserMete_key
        /// </summary>
        public virtual string UserMeta_key
        {
            get;
            set;
        }

        /// <summary>
        /// UserMeta_value
        /// </summary>
        public virtual string UserMeta_value
        {
            get;
            set;
        }
    }
}
