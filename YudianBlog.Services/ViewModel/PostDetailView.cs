using System;
using System.Collections.Generic;
using YudianBlog.Model.Post;

namespace YudianBlog.Services.ViewModel
{
    /// <summary>
    /// 文章详细视图
    /// </summary>
    public class PostDetailView
    {
        /// <summary>
        /// 每篇文章id
        /// </summary>
        public int Post_id
        {
            get;
            set;
        }

        /// <summary>
        /// 文章的作者的id(默认0)
        /// </summary>
        public int Post_user_id
        {
            get;
            set;
        }

        /// <summary>
        /// 每篇文章发表的时间
        /// </summary>
        public DateTime Post_date
        {
            get;
            set;
        }

        /// <summary>
        /// 文章的标题
        /// </summary>
        public string Post_title
        {
            get;
            set;
        }

        /// <summary>
        /// 每篇文章的具体内容
        /// </summary>
        public string Post_content
        {
            get;
            set;
        }

        /// <summary>
        /// 文章摘要
        /// </summary>
        public string Post_excerpt
        {
            get;
            set;
        }


        /// <summary>
        /// 文章名，varchar(200)值。这通常是用在生成permalink时，标识某篇文章的一段文本或数字，也即post slug
        /// </summary>
        public string Post_name
        {
            get;
            set;
        }

        /// <summary>
        /// 文章当前的状态
        /// </summary>
        public PostStatus Post_status
        {
            get;
            set;
        }

        /// <summary>
        /// 评论设置的状态
        /// </summary>
        public PostCommentStatus Post_comment_status
        {
            get;
            set;
        }

        /// <summary>
        /// 文章密码
        /// </summary>
        public string Post_password
        {
            get;
            set;
        }

        /// <summary>
        /// 文章最后修改的时间
        /// </summary>
        public DateTime Post_modified
        {
            get;
            set;
        }

        /// <summary>
        /// 文章的上级文章的ID.用来组织静态页面和子页面间的关系
        /// </summary>
        public int Post_parent
        {
            get;
            set;
        }

        /// <summary>
        /// 这是每篇文章的一个地址,默认是这样的形式: http://your.blog.site/?p=1，如：http://www.haoideas.com/?p=1，如果你形成permalink功能，则通常会是: 你的Wordpress站点地址+文章名。
        /// </summary>
        public string Post_address
        {
            get;
            set;
        }

        /// <summary>
        /// 文章类型
        /// </summary>
        public PostType Post_type
        {
            get;
            set;
        }

        /// <summary>
        /// 浏览量
        /// </summary>
        public int Post_viewcount
        {
            get;
            set;
        }

        /// <summary>
        /// 评论数
        /// </summary>
        public int Post_comment_count
        {
            get;
            set;
        }

        /// <summary>
        /// 作者简单视图
        /// </summary>
        public UserSimpleView UserInfo { get; set; }

        /// <summary>
        /// 分类表
        /// </summary>
        public IEnumerable<CategorySimpleView> CategoryInfo { get; set; }

        /// <summary>
        /// 文章额外信息表
        /// </summary>
        public IEnumerable<PostMetaView> PostMetaInfo { get; set; }
    }
}
