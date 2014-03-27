using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YudianBlog.Services.Messaging.Post
{
    /// <summary>
    /// 文章排序枚举
    /// </summary>
    public enum PostSortBy
    {
        /// <summary>
        /// 发表文章的时间倒序
        /// </summary>
        DateTimeDesc = 1,
        /// <summary>
        /// 发表文章的时间正序
        /// </summary>
        DateTimeAsc = 2
    }
}
