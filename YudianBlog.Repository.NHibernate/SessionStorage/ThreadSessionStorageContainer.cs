using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using System.Threading;
using NHibernate.Type;

namespace YudianBlog.Repository.NHibernate.SessionStorage
{
    /// <summary>
    /// 用于非Web环境的客户端环境
    /// </summary>
    public class ThreadSessionStorageContainer : ISessionStorageContainer
    {
        public static readonly Hashtable _nhSessions = new Hashtable();
        public ISession GetCurrentSession()
        {
            ISession nhSession = null;

            if (GetThreadName() == null)
            {
                return nhSession;
            }
            else
            {
                if (_nhSessions.Contains(GetThreadName()))
                {
                    nhSession = (ISession)_nhSessions[GetThreadName()];
                }
                return nhSession;
            }
        }


        public void Store(ISession session)
        {
            if (_nhSessions.Contains(GetThreadName()))
                _nhSessions[GetThreadName()] = session;
            else
                _nhSessions.Add(GetThreadName(), session);
        }

        /// <summary>
        /// 获取当前运行的线程
        /// </summary>
        /// <returns></returns>
        private object GetThreadName()
        {
            return Thread.CurrentThread.Name;
        }
    }
}
