using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using YudianBlog.Infrastructure.Querying;

namespace YudianBlog.Repository.NHibernate.Repositories
{
    /// <summary>
    /// Nhibernate解释器，将查询命令解释成Nhibernate能执行的命令
    /// </summary>
    public static class QueryTranslator
    {
        public static ICriteria TranslateIntoNHQuery<T>(this Query query, ICriteria criteria)
        {
            BuildQueryFrom(query, criteria);

            #region 排序

            if (query.OrderByProperty != null)
                criteria.AddOrder(new Order(query.OrderByProperty.PropertyName,
                                                  !query.OrderByProperty.Desc));
            #endregion

            return criteria;
        }

        /// <summary>
        /// 生成条件查询语句ICriteria
        /// </summary>
        /// <param name="query"></param>
        /// <param name="criteria"></param>
        private static void BuildQueryFrom(Query query, ICriteria criteria)
        {
            IList<ICriterion> _critrions = new List<ICriterion>();

            if (query.Criteria != null)
            {
                #region 确定操作符（<、>、+、>等）

                foreach (Criterion c in query.Criteria)
                {
                    ICriterion criterion;

                    switch (c.CriteriaOperators)
                    {
                        case CriteriaOperator.Equal:
                            criterion = Expression.Eq(c.PropertyName, c.Value);
                            break;
                        case CriteriaOperator.GreaterThan:
                            criterion = Expression.Gt(c.PropertyName, c.Value);
                            break;
                        case CriteriaOperator.GreaterThanOrEqual:
                            criterion = Expression.Ge(c.PropertyName, c.Value);
                            break;
                        case CriteriaOperator.LessThan:
                            criterion = Expression.Lt(c.PropertyName, c.Value);
                            break;
                        case CriteriaOperator.LesserThanOrEqual:
                            criterion = Expression.Le(c.PropertyName, c.Value);
                            break;
                        case CriteriaOperator.Like:
                            criterion = Expression.Like(c.PropertyName, c.Value);
                            break;
                        case CriteriaOperator.NotApplicable:
                            criterion = Expression.Not(Expression.Eq(c.PropertyName, c.Value));
                            break;
                        case CriteriaOperator.Btween:
                            criterion = Expression.Between(c.PropertyName, c.Value, c.Value2);
                            break;
                        default:
                            throw new ApplicationException("No operator defined");
                    }
                    _critrions.Add(criterion);
                }

                #endregion

                #region 确定连接符（And、Or）

                if (query.QueryOperator == QueryOperator.And)
                {
                    Conjunction addSubQuery = Expression.Conjunction();
                    foreach (ICriterion criterion in _critrions)
                    {
                        addSubQuery.Add(criterion);
                    }

                    criteria.Add(addSubQuery);
                }
                else
                {
                    Conjunction orSubQuery = Expression.Conjunction();
                    foreach (ICriterion criterion in _critrions)
                    {
                        orSubQuery.Add(criterion);
                    }

                    criteria.Add(orSubQuery);
                }

                #endregion

                #region 递归确定操作符和连接符

                foreach (Query sub in query.SubQueries)
                {
                    BuildQueryFrom(sub, criteria);
                }

                #endregion
            }

        }
    }
}
