﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成
//     如果重新生成代码，将丢失对此文件所做的更改。
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YudianBlog.Model.Comment
{
    /// <summary>
    /// 每个评论的当前状态
    /// </summary>
    public enum CommentApproved 
    {
        /// <summary>
        /// 允许发布
        /// </summary>
        allow = 1,

        /// <summary>
        /// 等待审核
        /// </summary>
        review = 2,

        /// <summary>
        /// 垃圾评论
        /// </summary>
        rubbish = 3,
    }
}