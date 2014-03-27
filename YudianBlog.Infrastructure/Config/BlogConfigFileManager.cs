using System;
using System.IO;
using YudianBlog.Infrastructure.Common;

namespace YudianBlog.Infrastructure.Config
{
    /// <summary>
    /// 博客基本信息
    /// </summary>
    public class BlogConfigFileManager : DefaultConfigFileManager
    {
        #region 静态构造函数

        /// <summary>
        /// 初始化文件修改时间和对象实例
        /// </summary>
        static BlogConfigFileManager()
        {
            m_fileoldchange = System.IO.File.GetLastWriteTime(ConfigFilePath);

            try
            {
                m_configinfo = (BlogConfigInfo)DefaultConfigFileManager.DeserializeInfo(ConfigFilePath, typeof(BlogConfigInfo));
            }
            catch
            {
                if (File.Exists(ConfigFilePath))
                {
                    m_configinfo = (BlogConfigInfo)DefaultConfigFileManager.DeserializeInfo(ConfigFilePath, typeof(BlogConfigInfo));
                }
            }
        }
        #endregion

        /// <summary>
        /// 博客基本信息类
        /// </summary>
        private static BlogConfigInfo m_configinfo;

        /// <summary>
        /// 文件修改时间
        /// </summary>
        private static DateTime m_fileoldchange;

        /// <summary>
        /// 配置文件所在路径
        /// </summary>
        private static string filename = null;

        /// <summary>
        /// 当前配置类的实例
        /// </summary>
        public new static IConfigInfo ConfigInfo
        {
            get { return m_configinfo; }
            set { m_configinfo = (BlogConfigInfo)value; }
        }

        /// <summary>
        /// 获取配置文件所在路径
        /// </summary>
        private new static string ConfigFilePath
        {
            get
            {
                if (filename == null)
                {
                    filename = Utils.GetMapPath("/Config/BlogConfig.config");
                }

                return filename;
            }

        }

        /// <summary>
        /// 返回配置类实例
        /// </summary>
        /// <returns></returns>
        public static BlogConfigInfo LoadConfig()
        {

            try
            {
                ConfigInfo = DefaultConfigFileManager.LoadConfig(ref m_fileoldchange, ConfigFilePath, ConfigInfo, true);
            }
            catch
            {
                ConfigInfo = DefaultConfigFileManager.LoadConfig(ref m_fileoldchange, ConfigFilePath, ConfigInfo, true);
            }
            return ConfigInfo as BlogConfigInfo;
        }

        /// <summary>
        /// 保存配置类实例
        /// </summary>
        /// <returns></returns>
        public override bool SaveConfig()
        {
            return base.SaveConfig(ConfigFilePath, ConfigInfo);
        }
    }
}