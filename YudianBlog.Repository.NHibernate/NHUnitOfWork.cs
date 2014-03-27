using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using YudianBlog.Infrastructure.Domain;
using YudianBlog.Infrastructure.UnitOfWork;
using YudianBlog.Repository.NHibernate.SessionStorage;

namespace YudianBlog.Repository.NHibernate
{
    public class NHUnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="unitofWorkRepository"></param>
        public void RegisterAmended(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            SessionFactory.GetCurrentSession().SaveOrUpdate(entity);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="unitofWorkRepository"></param>
        public void RegisterNew(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            SessionFactory.GetCurrentSession().Save(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="unitofWorkRepository"></param>
        public void RegisterRemoved(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            SessionFactory.GetCurrentSession().Delete(entity);
        }

        /// <summary>
        /// 提交
        /// </summary>
        public void Commit()
        {
            using (ITransaction transaction = SessionFactory.GetCurrentSession().BeginTransaction())
            {
                try
                {
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
