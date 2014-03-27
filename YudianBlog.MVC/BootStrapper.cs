using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StructureMap.Configuration.DSL;
using StructureMap;
using YudianBlog.Controllers;

namespace YudianBlog.MVC
{
    public class BootStrapper
    {
        /// <summary>
        /// 注册ControllerFactory
        /// </summary>
        public static void SetControllerFactory()
        {
            ControllerBuilder.Current.SetControllerFactory(new IoCControllerFactory());
        }


        public static void ConfigureDependencies()
        {
            ObjectFactory.Initialize(x =>
            {
                x.AddRegistry<ControllerRegistry>();

            });
        }

        public class ControllerRegistry : Registry
        {
            public ControllerRegistry()
            {
                ForRequestedType<YudianBlog.Infrastructure.UnitOfWork.IUnitOfWork>().TheDefault.Is.OfConcreteType
                        <YudianBlog.Repository.NHibernate.NHUnitOfWork>();

                ForRequestedType<YudianBlog.Model.Category.ICategoryRepository>().TheDefault.Is.OfConcreteType
                        <YudianBlog.Repository.NHibernate.Repositories.CategoryRepository>();

                ForRequestedType<YudianBlog.Model.Comment.ICommentRepository>().TheDefault.Is.OfConcreteType
                       <YudianBlog.Repository.NHibernate.Repositories.CommentRepository>();

                ForRequestedType<YudianBlog.Model.Link.ILinkRepository>().TheDefault.Is.OfConcreteType
                      <YudianBlog.Repository.NHibernate.Repositories.LinkRepository>();

                ForRequestedType<YudianBlog.Model.Option.IOptionRepository>().TheDefault.Is.OfConcreteType
                      <YudianBlog.Repository.NHibernate.Repositories.OptionsRepository>();

                ForRequestedType<YudianBlog.Model.Post.IPostRepository>().TheDefault.Is.OfConcreteType
                      <YudianBlog.Repository.NHibernate.Repositories.PostRepository>();

                ForRequestedType<YudianBlog.Model.User.IUserRepository>().TheDefault.Is.OfConcreteType
                     <YudianBlog.Repository.NHibernate.Repositories.UsersRepository>();

                ForRequestedType<YudianBlog.Services.Interfaces.ICategoryService>().TheDefault.Is.OfConcreteType
                     <YudianBlog.Services.Implementations.CategoryService>();

                ForRequestedType<YudianBlog.Services.Interfaces.IPostService>().TheDefault.Is.OfConcreteType
                     <YudianBlog.Services.Implementations.PostServices>();

                ForRequestedType<YudianBlog.Services.Interfaces.IUserService>().TheDefault.Is.OfConcreteType
                     <YudianBlog.Services.Implementations.UserService>();


            }
        }
    }
}