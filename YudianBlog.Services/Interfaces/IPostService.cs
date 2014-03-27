using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YudianBlog.Services.Messaging.Category;
using YudianBlog.Services.Messaging.Post;

namespace YudianBlog.Services.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPostService
    {
        GetFeaturePostRespose GetFeaturePost();

        GetPostByCategoryRespose GetPostsByCategory(GetPostByCategoryRequest getPostByCategoryRequest);

        GetPostByIdRespose GetPostById(GetPostByIdRequest getPostByIdRequest);
    }
}
