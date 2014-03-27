using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YudianBlog.Services.Messaging.Post
{
    /// <summary>
    /// 特殊文章，如置顶、热门、随机等
    /// </summary>
    public class GetFeaturePostRequest
    {
        /// <summary>
        /// 显示数目
        /// </summary>
        public int NumberOfPerPage { get; set; }

        /// <summary>
        /// 时间排序
        /// </summary>
        public PostSortBy Feature { get; set; }
    }
}
