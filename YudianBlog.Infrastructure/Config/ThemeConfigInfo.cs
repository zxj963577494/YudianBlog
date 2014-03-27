using System;
using System.Collections.Generic;

namespace YudianBlog.Infrastructure.Config
{
    /// <summary>
    /// 主题列表
    /// </summary>
    [Serializable]
    public class ThemeConfigInfoList: IConfigInfo
    {
        public List<ThemeConfigInfo> ConfigList{get; set; }

        public ThemeConfigInfoList(List<ThemeConfigInfo> configlist)
        {
            ConfigList = configlist;
        }
        public ThemeConfigInfoList()
        {
            ConfigList = new List<ThemeConfigInfo>();
        }

        /// <summary>
        /// 查找某个模块配置信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ThemeConfigInfo FindConfigById(string id)
        {
            if (ConfigList == null || ConfigList.Count == 0)
            {
                return null;
            }
            List<ThemeConfigInfo> list = ConfigList.FindAll(c=>c.ThemeId==id);
            if (list.Count == 0)
            {
                return null;
            }
            else
            {
                return list[0];
            }
        }
    }

    /// <summary>
    /// 主题
    /// </summary>
    [Serializable]
    public class ThemeConfigInfo
    {
         /// <summary>
        /// 主题ID
        /// </summary>
       public string ThemeId { get; set; }

        /// <summary>
        /// 主题名称
        /// </summary>
       public string ThemeName { get; set; }
       /// <summary>
       /// 主题对应程序版本
       /// </summary>	
       public string ThemeVersion { get; set; }
       /// <summary>
       /// 主题作者
       /// </summary>	
       public string ThemeAuthor{get; set; }
        /// <summary>
        /// 主题Email
        /// </summary>	
        public string ThemeEmail { get; set; }
        /// <summary>
        /// 主题作者网站
        /// </summary>	
        public string ThemeSiteUrl { get; set; }
        /// <summary>
        /// 主题发布日期
        /// </summary>	
        public string ThemePubDate { get; set; }
        /// <summary>
        /// 主题发布日期描述
        /// </summary>	
        public string ThemeDescript { get; set; }
          /// <summary>
        /// 主题是否启用(1启用0不启用)
        /// </summary>	
        public string ThemeEnabled  { get; set; }
       
    }
}