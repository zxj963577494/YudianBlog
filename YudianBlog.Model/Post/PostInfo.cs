using System;
using System.Collections.Generic;
using YudianBlog.Infrastructure.Domain;
using YudianBlog.Model.Category;
using YudianBlog.Model.Comment;
using YudianBlog.Model.User;

namespace YudianBlog.Model.Post
{
    public class PostInfo : EntityBase<int>, IAggregateRoot
    {
        /// <summary>
        /// 每篇文章id
        /// </summary>
        public virtual int Post_id
        {
            get;
            set;
        }

        /// <summary>
        /// 文章的作者的id(默认0)
        /// </summary>
        public virtual int Post_user_id
        {
            get;
            set;
        }

        /// <summary>
        /// 每篇文章发表的时间
        /// </summary>
        public virtual DateTime Post_date
        {
            get;
            set;
        }

        /// <summary>
        /// 文章的标题
        /// </summary>
        public virtual string Post_title
        {
            get;
            set;
        }

        /// <summary>
        /// 每篇文章的具体内容
        /// </summary>
        public virtual string Post_content
        {
            get;
            set;
        }

        /// <summary>
        /// 文章摘要
        /// </summary>
        public virtual string Post_excerpt
        {
            get;
            set;
        }


        /// <summary>
        /// 文章名，varchar(200)值。这通常是用在生成permalink时，标识某篇文章的一段文本或数字，也即post slug
        /// </summary>
        public virtual string Post_name
        {
            get;
            set;
        }

        /// <summary>
        /// 文章当前的状态
        /// </summary>
        public virtual PostStatus Post_status
        {
            get;
            set;
        }

        /// <summary>
        /// 评论设置的状态
        /// </summary>
        public virtual PostCommentStatus Post_comment_status
        {
            get;
            set;
        }

        /// <summary>
        /// 文章密码
        /// </summary>
        public virtual string Post_password
        {
            get;
            set;
        }

        /// <summary>
        /// 文章最后修改的时间
        /// </summary>
        public virtual DateTime Post_modified
        {
            get;
            set;
        }

        /// <summary>
        /// 文章的上级文章的ID.用来组织静态页面和子页面间的关系
        /// </summary>
        public virtual int Post_parent
        {
            get;
            set;
        }

        /// <summary>
        /// 这是每篇文章的一个地址,默认是这样的形式: http://your.blog.site/?p=1，如：http://www.haoideas.com/?p=1，如果你形成permalink功能，则通常会是: 你的Wordpress站点地址+文章名。
        /// </summary>
        public virtual string Post_address
        {
            get;
            set;
        }

        /// <summary>
        /// 文章类型
        /// </summary>
        public virtual PostType Post_type
        {
            get;
            set;
        }

        /// <summary>
        /// 浏览量
        /// </summary>
        public virtual int Post_viewcount
        {
            get;
            set;
        }

        /// <summary>
        /// 评论数
        /// </summary>
        public virtual int Post_comment_count
        {
            get;
            set;
        }

        /// <summary>
        /// 文章表-文章额外属性表
        /// </summary>
        public virtual IEnumerable<PostMetaInfo> PostMetaInfo
        {
            get;
            set;
        }

        /// <summary>
        /// 评论表
        /// </summary>
        public virtual IEnumerable<CommentInfo> CommentInfo
        {
            get;
            set;
        }

        /// <summary>
        /// 用户表-文章表
        /// </summary>
        public virtual UserInfo UserInfo
        {
            get;
            set;
        }

        /// <summary>
        /// 分类-文章表
        /// </summary>
        public virtual IEnumerable<CategoryInfo> CategoryInfo
        {
            get;
            set;
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}

