using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YudianBlog.Infrastructure.Querying
{
    /// <summary>
    /// 查询命令，组合查询过滤器,会将此翻译成NHibernate或EntityFramework理解的句子
    /// </summary>
    public class Query
    {
        /// <summary>
        /// 子查询集合
        /// </summary>
        private IList<Query> _subQueries = new List<Query>();

        /// <summary>
        /// 查询过滤器集合
        /// </summary>
        private IList<Criterion> _criteria = new List<Criterion>();

        /// <summary>
        /// 查询过滤器集合
        /// </summary>
        public IEnumerable<Criterion> Criteria
        {
            get { return _criteria; }
        }

        /// <summary>
        /// 子查询集合
        /// </summary>
        public IEnumerable<Query> SubQueries
        {
            get { return _subQueries; }
        }

        /// <summary>
        /// 添加查询命令
        /// </summary>
        /// <param name="subQuery"></param>
        public void AddSubQuery(Query subQuery)
        {
            _subQueries.Add(subQuery);
        }

        /// <summary>
        /// 添加查询过滤器
        /// </summary>
        /// <param name="criterion"></param>
        public void Add(Criterion criterion)
        {
            _criteria.Add(criterion);
        }

        /// <summary>
        /// 连接符
        /// </summary>
        public QueryOperator QueryOperator { get; set; }

        /// <summary>
        /// 排序属性的类
        /// </summary>
        public OrderByClause OrderByProperty { get; set; }
    }
}
