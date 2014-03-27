namespace YudianBlog.Services.Messaging.Post
{
    /// <summary>
    /// 获取文章详细页
    /// </summary>
    public class GetPostByIdRequest
    {
        /// <summary>
        /// 文章ID
        /// </summary>
        public int PostId { get; set; }
    }
}
