using System.Collections.Generic;
using YudianBlog.Services.ViewModel;

namespace YudianBlog.Services.Messaging.Post
{
    /// <summary>
    /// 获取某分类中的文章 响应类
    /// </summary>
    public class GetPostByCategoryRespose
    {
        /// <summary>
        /// 分类名称
        /// </summary>
        public string SelectCategoryName { get; set; }

        /// <summary>
        /// 分类ID
        /// </summary>
        public int SelectCategory { get; set; }

        /// <summary>
        /// 文章总数
        /// </summary>
        public int NumberOfTitlesFound { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalNumberOfPages { get; set; }

        /// <summary>
        /// 当前页
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// 文章列表视图
        /// </summary>
        public IEnumerable<PostListView> PostList { get; set; }
    }
}
