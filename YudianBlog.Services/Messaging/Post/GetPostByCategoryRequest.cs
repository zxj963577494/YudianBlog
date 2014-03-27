using System.Collections.Generic;
using YudianBlog.Model.Post;

namespace YudianBlog.Services.Messaging.Post
{
    /// <summary>
    /// 获取某分类中的文章 请求类
    /// </summary>
    public class GetPostByCategoryRequest
    {
        /// <summary>
        /// 排序方式
        /// </summary>
        public PostSortBy Sort { get; set; }

        /// <summary>
        /// 文章类型
        /// </summary>
        public PostType PostType { get; set; }

        /// <summary>
        /// 文章当前的状态
        /// </summary>
        public PostStatus PostStatus { get; set; }

        /// <summary>
        /// 评论设置的状态
        /// </summary>
        public PostCommentStatus PostCommentStatus { get; set; }

        /// <summary>
        /// 分类ID
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// 当前页
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// 每页显示的记录数
        /// </summary>
        public int NumberOfResultsPerPage { get; set; }
    }
}
