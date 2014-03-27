using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using YudianBlog.Model.Category;
using YudianBlog.Services.ViewModel;

namespace YudianBlog.Services.Mapping
{
    public static class CategoryMapper
    {
        /// <summary>
        /// 列表类型之间的映射,普通转换
        /// </summary>
        /// <param name="categories"></param>
        /// <returns></returns>
        public static IEnumerable<CategorySimpleView> ConvertToCategorySimpleView(
                                              this IEnumerable<CategoryInfo> categories)
        {
            return Mapper.Map<IEnumerable<CategoryInfo>,
                IEnumerable<CategorySimpleView>>(categories);
        }
    }
}
