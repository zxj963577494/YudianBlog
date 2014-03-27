using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using NHibernate;
using NHibernate.Cfg;
using YudianBlog.Infrastructure.Common;
using YudianBlog.Infrastructure.Configuration;
using YudianBlog.Infrastructure.Logging;

namespace YudianBlog.Repository.NHibernate.SessionStorage
{
    /// <summary>
    /// 创建会话
    /// </summary>
    public static class SessionFactory
    {
        private static ISessionFactory _sessionFactory;

        /// <summary>
        /// 创建IsessionFactory实例
        /// </summary>
        private static void Init()
        {
            Configuration config = new Configuration().Configure(Utils.GetMapPath("/Config/nhibernate.cfg.config"));
            //Log4NetAdapter log = new Log4NetAdapter();
            //添加包含内嵌映射元数据的程序集，让NHibernate自动到程序集加载所有的嵌入式资源xml映射文件
            //config.AddAssembly("YudianBlog.Repository.NHibernate");
            //调用该配置实例来创建IsessionFactory的一个实例
            _sessionFactory = config.BuildSessionFactory();
        }

        /// <summary>
        /// 获取ISessionFactory实例
        /// </summary>
        /// <returns></returns>
        private static ISessionFactory GetSessionFactory()
        {
            if (_sessionFactory == null)
            {
                Init();
            }

            return _sessionFactory;
        }

        /// <summary>
        /// 获取ISession实例
        /// </summary>
        /// <returns></returns>
        private static ISession GetNewSession()
        {
            return GetSessionFactory().OpenSession();
        }

        /// <summary>
        /// 创建一个新实例会话并将其存储在适合的会话容器中（在Repository实现中调用）
        /// </summary>
        /// <returns></returns>
        public static ISession GetCurrentSession()
        {
            ISessionStorageContainer sessionStorageContainer =
                                       SessionStorageFactory.GetStorageContainer();

            ISession currentSession = sessionStorageContainer.GetCurrentSession();

            if (currentSession == null)
            {
                //创建新的会话
                currentSession = GetNewSession();
                //保存会话
                sessionStorageContainer.Store(currentSession);
            }

            return currentSession;
        }

    }
}
