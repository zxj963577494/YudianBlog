using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace YudianBlog.Infrastructure.Querying
{
    /// <summary>
    /// 查询过滤器,指定要比较的实体属性和比较的方式
    /// </summary>
    public class Criterion
    {
        /// <summary>
        /// 实体属性
        /// </summary>
        public string PropertyName { get; private set; }

        /// <summary>
        /// 进行比较的值(在Between操作符时为lo,主要运用于时间)
        /// </summary>
        public object Value { get; private set; }

        /// <summary>
        /// 进行比较的值(在Between操作符时为hi,主要运用于时间,其余时间为null)
        /// </summary>
        public object Value2 { get; private set; }

        /// <summary>
        /// 比较操作符
        /// </summary>
        public CriteriaOperator CriteriaOperators { get; private set; }

        /// <summary>
        /// 初始化值
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        /// <param name="criteriaOperators"></param>
        /// <param name="value2"></param>
        public Criterion(string propertyName, object value, CriteriaOperator criteriaOperators, object value2 = null)
        {
            PropertyName = propertyName;
            Value = value;
            Value2 = value2;
            CriteriaOperators = criteriaOperators;
        }

        /*
         * 调用示例：
         * aQuery.Add(Criterion.Create<Product>(p=>p.Id,Id,CriteriaOperator.Equal));
         * 
         */

        /// <summary>
        /// 对外公开的方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression">实体属性的表达式</param>
        /// <param name="value">进行比较的值(在Between操作符时为lo,主要运用于时间)</param>
        /// <param name="criteriaOperator">比较操作符</param>
        /// <param name="value2">进行比较的值(在Between操作符时为hi,主要运用于时间,其余情况为null)</param>
        /// <returns>查询过滤器实例</returns>
        public static Criterion Create<T>(Expression<Func<T, object>> expression, object value, CriteriaOperator criteriaOperator, object value2 = null)
        {
            string propertyName = PropertyNameHelper.ResolvePropertyName<T>(expression);
            Criterion myCriterion = new Criterion(propertyName, value, criteriaOperator, value2);
            return myCriterion;
        }

        /// <summary>
        /// 对外公开的方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression">实体属性的表达式</param>
        /// <param name="value">进行比较的值(在Between操作符时为lo,主要运用于时间)</param>
        /// <param name="criteriaOperator">比较操作符</param>
        /// <param name="value2">进行比较的值(在Between操作符时为hi,主要运用于时间,其余情况为null)</param>
        /// <returns>查询过滤器实例</returns>
        public static Criterion Create<T>(string expression, object value, CriteriaOperator criteriaOperator, object value2 = null)
        {
            string propertyName = expression;
            Criterion myCriterion = new Criterion(propertyName, value, criteriaOperator, value2);
            return myCriterion;
        }
    }
}
