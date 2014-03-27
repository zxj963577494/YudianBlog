#region

using System;
using System.Collections.Generic;
using YudianBlog.Infrastructure.Domain;
using YudianBlog.Model.Link;
using YudianBlog.Model.Post;

#endregion

namespace YudianBlog.Model.Category
{
    /// <summary>
    /// 文章分类、链接分类、标签的信息表。
    /// </summary>
    public class CategoryInfo : EntityBase<int>, IAggregateRoot
    {
        /// <summary>
        /// 分类Id
        /// </summary>
        public virtual int Category_id
        {
            get;
            set;
        }

        /// <summary>
        /// 分类描述
        /// </summary>
        public virtual string Category_description
        {
            get;
            set;
        }

        /// <summary>
        /// 分类类型
        /// </summary>
        public virtual CategoryType Category_type
        {
            get;
            set;
        }

        /// <summary>
        /// 分类分组
        /// </summary>
        public virtual int Category_group
        {
            get;
            set;
        }

        /// <summary>
        /// 分类缩略名
        /// </summary>
        public virtual string Category_slug
        {
            get;
            set;
        }

        /// <summary>
        /// 分类名
        /// </summary>
        public virtual string Category_name
        {
            get;
            set;
        }

        /// <summary>
        /// 分类创建时间
        /// </summary>
        public virtual DateTime Category_addtime
        {
            get;
            set;
        }

        /// <summary>
        /// 分类下文章数目
        /// </summary>
        public virtual int Category_count
        {
            get;
            set;
        }

        /// <summary>
        /// 分类父 id（默认0）
        /// </summary>
        public virtual int Category_parent
        {
            get;
            set;
        }

        /// <summary>
        /// 文章表
        /// </summary>
        public virtual IEnumerable<PostInfo> PostInfo
        {
            get;
            set;
        }

        /// <summary>
        /// 链接表
        /// </summary>
        public virtual IEnumerable<LinkInfo> LinkInfo
        {
            get;
            set;
        }


        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }

}