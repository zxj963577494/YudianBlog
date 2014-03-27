using System.Collections.Generic;
using YudianBlog.Services.ViewModel;

namespace YudianBlog.Services.Messaging.Category
{
    /// <summary>
    /// 分类
    /// </summary>
    public class GetAllSimpleCategoryRespose
    {
        /// <summary>
        /// 简单分类视图
        /// </summary>
        public IEnumerable<CategorySimpleView> CategorySimple
        {
            get;
            set;
        }
    }
}
