using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YudianBlog.Infrastructure.Querying
{
    /// <summary>
    /// 排序属性的类
    /// </summary>
    public class OrderByClause
    {
        /// <summary>
        /// 属性名对应数据库表的列名
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// 是否倒序
        /// </summary>
        public bool Desc { get; set; }
    }
}
