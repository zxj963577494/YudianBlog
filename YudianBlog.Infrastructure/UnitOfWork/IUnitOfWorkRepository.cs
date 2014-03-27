using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YudianBlog.Infrastructure.Domain;

namespace YudianBlog.Infrastructure.UnitOfWork
{
    /// <summary>
    /// 定义对应的持久化工作
    /// </summary>
    public interface IUnitOfWorkRepository
    {
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="entity"></param>
        void PersistCreationOf(IAggregateRoot entity);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        void PersistUpdateOf(IAggregateRoot entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        void PersistDeletionOf(IAggregateRoot entity);
    }
}
