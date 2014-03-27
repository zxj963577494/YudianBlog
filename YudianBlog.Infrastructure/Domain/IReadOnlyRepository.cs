using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YudianBlog.Infrastructure.Querying;

namespace YudianBlog.Infrastructure.Domain
{
    /// <summary>
    /// 只读接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TId"></typeparam>
    public interface IReadOnlyRepository<T, TId> where T : IAggregateRoot
    {
        /// <summary>
        /// 通过Id获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T FindBy(TId id);
        /// <summary>
        /// 获取所有实体
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> FindAll();
        /// <summary>
        /// 通过查询对象获取实体
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        IEnumerable<T> FindBy(Query query);
        /// <summary>
        /// 通过查询对象进行分页处理
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <param name="index">当前页</param>
        /// <param name="count">每页显示的记录数</param>
        /// <returns></returns>
        IEnumerable<T> FindBy(Query query, int index, int count);
    }
}
