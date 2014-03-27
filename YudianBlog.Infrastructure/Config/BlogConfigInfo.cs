using System;

namespace YudianBlog.Infrastructure.Config
{
    /// <summary>
    /// 博客基本信息
    /// </summary>
    [Serializable]
    public class BlogConfigInfo : IConfigInfo
    {

        /// <summary>
        /// 网站名称
        /// </summary>
       public string WebSiteName { get; set; }
       /// <summary>
       /// 网站标题
       /// </summary>	
       public string WebSiteTitle { get; set; }
       /// <summary>
       /// 网站关键词
       /// </summary>	
       public string MeteKey{get; set; }
        /// <summary>
        /// 网站描述信息
        /// </summary>	
        public string MeteInfo { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>	
        public string Tel { get; set; }
        /// <summary>
        /// E-mail
        /// </summary>	
        public string Email { get; set; }
        /// <summary>
        /// 网站路径
        /// </summary>	
        public string WebSitePath { get; set; }
        /// <summary>
        /// HTTP地址
        /// </summary>	
        public string WebSiteDomain { get; set; }
        /// <summary>
        /// 统计代码
        /// </summary>	
        public string StatisticsCode { get; set; }
        /// <summary>
        /// 是否关闭网站
        /// </summary>	
        public int IsCloseWebSite { get; set; }
        /// <summary>
        /// 网站关闭信息
        /// </summary>	
        public string CloseWebSiteInfo { get; set; }
        /// <summary>
        /// 版权信息
        /// </summary>	
        public string CopyRight { get; set; }
        /// <summary>
        /// 网站访问模式(静态/动态)
        /// </summary>	
        public int PublicMethod { get; set; }

        /// <summary>
        /// 静态链接后缀名(.aspx/.html等)
        /// </summary>	
        public string StaticPageFileType { get; set; }
    }
}