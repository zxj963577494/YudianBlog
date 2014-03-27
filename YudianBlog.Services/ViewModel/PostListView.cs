using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YudianBlog.Services.ViewModel
{
    /// <summary>
    /// 文章列表视图
    /// </summary>
    public class PostListView
    {
        /// <summary>
        /// 主键ID
        /// </summary>	
        public int Post_id { get; set; }

        /// <summary>
        /// 文章的作者的id(默认0)
        /// </summary>
        public int Post_user_id{get;set;}

        /// <summary>
        /// 每篇文章发表的时间
        /// </summary>	
        public DateTime Post_date { get; set; }

        /// <summary>
        /// 文章的标题
        /// </summary>	
        public string Post_title { get; set; }

        /// <summary>
        /// 文章摘要
        /// </summary>	
        public string Post_excerpt { get; set; }

        /// <summary>
        /// 每篇文章的具体内容
        /// </summary>	
        public string Post_content { get; set; }

        /// <summary>
        /// 评论计数（默认0）
        /// </summary>	
        public int Post_comment_count { get; set; }

        /// <summary>
        /// 浏览计数（默认0）
        /// </summary>	
        public int Post_viewcount { get; set; }

        /// <summary>
        /// 类别简单视图
        /// </summary>
        public IEnumerable<CategorySimpleView> CategoryInfo { get; set; }

    }
}
