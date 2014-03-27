#region

using System;
using System.Collections.Generic;
using YudianBlog.Infrastructure.Domain;
using YudianBlog.Model.Category;

#endregion

namespace YudianBlog.Model.Link
{
    ///<summary>
    ///说明:链接表
    ///</summary>
    public class LinkInfo : EntityBase<int>, IAggregateRoot
    {
        /// <summary>
        /// 每个链接的唯一ID号
        /// </summary>	
        public virtual int Link_id { get; set; }
        /// <summary>
        /// 每个链接的URL地址,形式为http://开头的地址
        /// </summary>	
        public virtual string Link_url { get; set; }
        /// <summary>
        /// 单个链接的名字
        /// </summary>	
        public virtual string Link_name { get; set; }
        /// <summary>
        /// 链接可以被定义为使用图片链接，这个字段用于保存该图片的地址
        /// </summary>	
        public virtual string Link_image { get; set; }
        /// <summary>
        /// 链接打开的方式，有三种，_blank为以新窗口打开，_top为就在本窗口中打开并在最上一级，none为不选择，会在本窗口中打开。
        /// </summary>	
        public virtual LinkTarget Link_target { get; set; }
        /// <summary>
        /// 链接的说明文字。用户可以选择显示在链接下方还是显示在title属性中
        /// </summary>	
        public virtual string Link_description { get; set; }
        /// <summary>
        /// 该链接是否可见，（默认为1，即可见）
        /// </summary>	
        public virtual int Link_visible { get; set; }
        /// <summary>
        /// 某个链接的创建人(默认是1。应该对应的就是wp_users.ID)
        /// </summary>	
        public virtual int Link_owner { get; set; }
        /// <summary>
        /// 链接的等级（默认是0）
        /// </summary>	
        public virtual int Link_rating { get; set; }
        /// <summary>
        /// 链接被定义,修改的时间（默认现在时间）
        /// </summary>	
        public virtual DateTime Link_updated { get; set; }
        /// <summary>
        /// 链接与定义者的关系
        /// </summary>	
        public virtual string Link_rel { get; set; }
        /// <summary>
        /// 链接的详细说明
        /// </summary>	
        public virtual string Link_notes { get; set; }
        /// <summary>
        /// 该链接的RSS地址
        /// </summary>	
        public virtual string Link_rss { get; set; }

        /// <summary>
        /// 类别表
        /// </summary>
        public virtual IEnumerable<CategoryInfo> CategoryInfo { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}