using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace YudianBlog.Repository.NHibernate.SessionStorage
{
    /// <summary>
    /// 定义通用的会话容器通信接口，因为无法预知是Web环境还是Window环境
    /// </summary>
    public interface ISessionStorageContainer
    {
        /// <summary>
        /// 获取ISession
        /// </summary>
        /// <returns></returns>
        ISession GetCurrentSession();
        void Store(ISession session);
    }
}
