using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YudianBlog.Infrastructure.Querying
{
    /// <summary>
    /// 处理查询条件的映射
    /// </summary>
    public enum CriteriaOperator
    {
        Equal,              // ==    
        LesserThanOrEqual,  // <=
        NotApplicable,      // !=
        LessThan,           // <
        GreaterThan,        // >
        GreaterThanOrEqual, // >=
        Like,               // %
        Btween
    }
}
