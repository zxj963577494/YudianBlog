namespace YudianBlog.Infrastructure.Config
{
    /// <summary>
    /// 博客基本信息
    /// </summary>
    public static class ThemeConfigs
    {
        /// <summary>
        /// 获取配置类实例
        /// </summary>
        /// <returns></returns>
        public static ThemeConfigInfoList GetConfig()
        {
            return ThemeConfigFileManager.LoadConfig();
        }

        /// <summary>
        /// 保存配置类实例
        /// </summary>
        /// <returns></returns>
        public static bool SaveConfig(ThemeConfigInfoList scripteventconfiginfo)
        {
            ThemeConfigFileManager scfm = new ThemeConfigFileManager();
            ThemeConfigFileManager.ConfigInfo = scripteventconfiginfo;
            return scfm.SaveConfig();
        }
    }
}
