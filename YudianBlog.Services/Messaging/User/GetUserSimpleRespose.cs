using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YudianBlog.Services.ViewModel;

namespace YudianBlog.Services.Messaging.User
{
    public class GetUserSimpleRespose
    {
        /// <summary>
        /// 简洁作者视图
        /// </summary>
        public UserSimpleView UserSimple { get; set; }
    }
}
