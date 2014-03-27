using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace YudianBlog.Infrastructure.Querying
{
    /// <summary>
    /// 使用表达式参数，避免使用字符串
    /// </summary>
    public static class PropertyNameHelper
    {
        public static string ResolvePropertyName<T>(
                           Expression<Func<T, object>> expression)
        {
            var expr = expression.Body as MemberExpression;
            if (expr == null)
            {
                var u = expression.Body as UnaryExpression;
                expr = u.Operand as MemberExpression;
            }
            return expr.ToString().Substring(expr.ToString().IndexOf(".") + 1);
        }
    }
}
