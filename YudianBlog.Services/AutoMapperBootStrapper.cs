using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using YudianBlog.Model.Category;
using YudianBlog.Model.Post;
using YudianBlog.Model.User;
using YudianBlog.Services.ViewModel;

namespace YudianBlog.Services
{
    /// <summary>
    /// 领域模式--视图模型转换类
    /// </summary>
    public class AutoMapperBootStrapper
    {

        public static void ConfigureAutoMapper()
        {
            //Category
            Mapper.CreateMap<CategoryInfo, CategorySimpleView>();

            //Post
            Mapper.CreateMap<PostInfo, PostSimpleView>();

            Mapper.CreateMap<PostInfo, PostDetailView>();

            Mapper.CreateMap<PostInfo, PostListView>();

            //User
            Mapper.CreateMap<UserInfo, UserDetailView>();
            Mapper.CreateMap<UserInfo, UserSimpleView>();
            Mapper.CreateMap<UserMetaInfo, UserMetaView>();


        }
    }
}
