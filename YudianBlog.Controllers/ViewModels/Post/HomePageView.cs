using System;
using System.Collections;
using System.Collections.Generic;
using YudianBlog.Services.ViewModel;

namespace YudianBlog.Controllers.ViewModels.Post
{
    public class HomePageView : BasePostPageView
    {
        public IEnumerable<PostListView> PostList { get; set; }

        public IEnumerable<PostSimpleView> PostSimple { get; set; }

        public UserDetailView UserDetail { get; set; }
    }
}
