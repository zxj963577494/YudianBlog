using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YudianBlog.Services.ViewModel;

namespace YudianBlog.Services.Messaging.Post
{
    /// <summary>
    /// 所有文章
    /// </summary>
    public class GetPostAllRespose
    {
        /// <summary>
        /// 简洁文章视图
        /// </summary>
        public List<PostSimpleView> PostSimple { get; set; }
    }
}
