using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using log4net;
using YudianBlog.Infrastructure.Configuration;
using Utils = YudianBlog.Infrastructure.Common.Utils;

namespace YudianBlog.Infrastructure.Logging
{
    public class Log4NetAdapter
    {
        private readonly log4net.ILog _log;

        public Log4NetAdapter()
        {
            log4net.Config.XmlConfigurator.Configure(new FileInfo(Utils.GetMapPath("/config/log4net.config")));
            _log = LogManager
             .GetLogger(ApplicationSettingsFactory.GetApplicationSettings().LoggerName);
        }

        public void Log(string message)
        {
            _log.Info(message);
        }
    }
}
