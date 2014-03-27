using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YudianBlog.Model.Category;

namespace YudianBlog.Services.ViewModel
{
    /// <summary>
    /// 类别简单视图(如导航条、标签)
    /// </summary>
    public class CategorySimpleView
    {
        /// <summary>
        /// 分类Id
        /// </summary>
        public virtual int Category_id
        {
            get;
            set;
        }

        /// <summary>
        /// 分类缩略名
        /// </summary>
        public virtual string Category_slug
        {
            get;
            set;
        }

        /// <summary>
        /// 分类名
        /// </summary>
        public virtual string Category_name
        {
            get;
            set;
        }

    }
}
