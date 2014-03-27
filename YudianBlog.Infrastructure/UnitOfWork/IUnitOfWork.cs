using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YudianBlog.Infrastructure.Domain;

namespace YudianBlog.Infrastructure.UnitOfWork
{
    /// <summary>
    /// UnitOfWork接口，使多个聚合根在一个原子操作中完成持久化
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="unitofWorkRepository"></param>
        void RegisterAmended(IAggregateRoot entity,
                             IUnitOfWorkRepository unitofWorkRepository);
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="unitofWorkRepository"></param>
        void RegisterNew(IAggregateRoot entity,
                         IUnitOfWorkRepository unitofWorkRepository);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="unitofWorkRepository"></param>
        void RegisterRemoved(IAggregateRoot entity,
                             IUnitOfWorkRepository unitofWorkRepository);

        /// <summary>
        /// 提交，使用.NET事务
        /// </summary>
        void Commit();
    }
}
