using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using YudianBlog.Controllers.Attribute;
using YudianBlog.Controllers.ViewModels.Post;
using YudianBlog.Model.Post;
using YudianBlog.Services.Implementations;
using YudianBlog.Services.Interfaces;
using YudianBlog.Services.Messaging.Post;
using YudianBlog.Services.Messaging.User;

namespace YudianBlog.Controllers.Controllers
{
    public class HomeController : PostBaseController
    {
        private readonly IPostService _postService;
        private readonly IUserService _userService;

        public HomeController(ICategoryService categoryService, IPostService postService, IUserService userService)
            : base(categoryService)
        {
            _postService = postService;
            _userService = userService;
        }

        [ThemesRelevant]
        public ActionResult Index()
        {
            HomePageView homePageView = new HomePageView();

            homePageView.Categories = base.GetCategories();

            GetPostByCategoryRequest request = new GetPostByCategoryRequest
            {
                CategoryId = 1,
                Index = 1,
                NumberOfResultsPerPage = 10,
                PostCommentStatus = PostCommentStatus.open,
                PostType = PostType.post,
                PostStatus = PostStatus.open,
                Sort = PostSortBy.DateTimeDesc
            };
            GetPostByCategoryRespose postByCategoryRespose = _postService.GetPostsByCategory(request);
            homePageView.PostList = postByCategoryRespose.PostList;


            GetFeaturePostRespose featurePostRespose = _postService.GetFeaturePost();
            homePageView.PostSimple = featurePostRespose.PostSimple;

            GetUserDetailRespose userDetailRespose = _userService.GetUserDetail();
            homePageView.UserDetail = userDetailRespose.UserDetail;

            return View(homePageView);
        }
    }
}
