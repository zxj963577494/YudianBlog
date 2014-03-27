using System.Collections.Generic;
using YudianBlog.Services.ViewModel;

namespace YudianBlog.Services.Messaging.Post
{
    /// <summary>
    /// 特殊文章，如置顶、热门、随机等
    /// </summary>
    public class GetFeaturePostRespose
    {
        /// <summary>
        /// 简洁文章视图
        /// </summary>
        public IEnumerable<PostSimpleView> PostSimple { get; set; }
    }
}
