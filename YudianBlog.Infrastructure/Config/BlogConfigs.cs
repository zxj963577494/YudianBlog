namespace YudianBlog.Infrastructure.Config
{
    /// <summary>
    /// 博客基本信息
    /// </summary>
    public class BlogConfigs
    {
        /// <summary>
        /// 获取配置类实例
        /// </summary>
        /// <returns></returns>
        public static BlogConfigInfo GetConfig()
        {
            return BlogConfigFileManager.LoadConfig();
        }

        /// <summary>
        /// 保存配置类实例
        /// </summary>
        /// <returns></returns>
        public static bool SaveConfig(BlogConfigInfo scripteventconfiginfo)
        {
            BlogConfigFileManager scfm = new BlogConfigFileManager();
            BlogConfigFileManager.ConfigInfo = scripteventconfiginfo;
            return scfm.SaveConfig();
        }
    }
}
