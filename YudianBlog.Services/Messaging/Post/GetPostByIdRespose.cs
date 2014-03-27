using YudianBlog.Services.ViewModel;

namespace YudianBlog.Services.Messaging.Post
{
    /// <summary>
    /// 获取文章详细页
    /// </summary>
    public class GetPostByIdRespose
    {
        /// <summary>
        /// 详细文章视图
        /// </summary>
        public PostDetailView PostsDetail { get; set; }
    }
}
