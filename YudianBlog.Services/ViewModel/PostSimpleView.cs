using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YudianBlog.Services.ViewModel
{
    /// <summary>
    /// 简单文章列表
    /// </summary>
    public class PostSimpleView
    {
        /// <summary>
        /// 主键ID
        /// </summary>	
        public int Post_id { get; set; }
        /// <summary>
        /// 文章的标题
        /// </summary>	
        public string Post_title { get; set; }

        /// <summary>
        /// 评论计数（默认0）
        /// </summary>	
        public int Post_comment_count { get; set; }

        /// <summary>
        /// 浏览计数（默认0）
        /// </summary>	
        public int Post_viewcount { get; set; }
    }
}
