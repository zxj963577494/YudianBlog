using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace YudianBlog.Repository.NHibernate.SessionStorage
{
    /// <summary>
    /// 工厂类，负责创建并提供有效的会话容器
    /// </summary>
    public static class SessionStorageFactory
    {
        private static ISessionStorageContainer _nhSessionStorageContainer;
        /// <summary>
        /// 获取适合的会话容器
        /// </summary>
        /// <returns></returns>
        public static ISessionStorageContainer GetStorageContainer()
        {
            if (_nhSessionStorageContainer == null)
            {
                if (HttpContext.Current == null)
                {
                    _nhSessionStorageContainer = new ThreadSessionStorageContainer();
                }
                else
                {
                    _nhSessionStorageContainer = new HttpSessionContainer();
                }
            }
            return _nhSessionStorageContainer;
        }
    }
}
