using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using NHibernate;
using YudianBlog.Infrastructure.Domain;
using YudianBlog.Infrastructure.Querying;
using YudianBlog.Infrastructure.UnitOfWork;
using YudianBlog.Repository.NHibernate.SessionStorage;

namespace YudianBlog.Repository.NHibernate.Repositories
{
    public abstract class Repository<T, EntityKey> where T : IAggregateRoot
    {
        private readonly IUnitOfWork _uow;

        protected Repository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity">实体对象</param>
        public void Add(T entity)
        {
            _uow.RegisterNew(entity, null);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">实体对象</param>
        public void Remove(T entity)
        {
            _uow.RegisterRemoved(entity, null);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">实体对象</param>
        public void Save(T entity)
        {
            _uow.RegisterAmended(entity, null);
        }

        /// <summary>
        /// 通过id获取实体
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public T FindBy(EntityKey id)
        {
            var currentSession = SessionFactory.GetCurrentSession();
            return currentSession.Get<T>(id);
        }

        /// <summary>
        /// 获取全部实体
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> FindAll()
        {
            ICriteria criteria = SessionFactory.GetCurrentSession().CreateCriteria(typeof(T));
            return criteria.List<T>();
        }

        /// <summary>
        /// 获取固定记录数
        /// </summary>
        /// <param name="index">起始数</param>
        /// <param name="count">记录数</param>
        /// <returns></returns>
        public IEnumerable<T> FindAll(int index, int count)
        {
            ICriteria criteria = SessionFactory.GetCurrentSession().CreateCriteria(typeof(T));

            return criteria.SetFetchSize(count)
                .SetFirstResult(index).List<T>();
        }

        /// <summary>
        /// 通过查询对象获取实体
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns></returns>
        public IEnumerable<T> FindBy(Query query)
        {
            ICriteria criteriaQuery = SessionFactory.GetCurrentSession().CreateCriteria(typeof(T));
            AppendCriteria(criteriaQuery);
            query.TranslateIntoNHQuery<T>(criteriaQuery);
            return criteriaQuery.List<T>();
        }

        /// <summary>
        /// 通过查询对象进行分页处理
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <param name="index">当前页</param>
        /// <param name="count">每页显示的记录数</param>
        /// <returns></returns>
        public IEnumerable<T> FindBy(Query query, int index, int count)
        {
            ICriteria criteriaQuery =
                SessionFactory.GetCurrentSession().CreateCriteria(typeof (T));
            AppendCriteria(criteriaQuery);
            query.TranslateIntoNHQuery<T>(criteriaQuery);
            return criteriaQuery.SetFirstResult((index - 1) * count).SetMaxResults(count).List<T>();
        }

        public virtual void AppendCriteria(ICriteria criteria)
        {

        }
    }
}
