using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YudianBlog.Infrastructure.Domain
{
    /// <summary>
    /// 业务规则类
    /// </summary>
    public class BusinessRule
    {
        /// <summary>
        /// 属性
        /// </summary>
        public string Property { get; private set; }

        /// <summary>
        /// 规则
        /// </summary>
        public string Rule { get; private set; }


        public BusinessRule(string property, string rule)
        {
            Property = property;
            Rule = rule;
        }
    }
}
