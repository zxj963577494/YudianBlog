using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using YudianBlog.Services.Interfaces;
using YudianBlog.Services.Messaging.Category;
using YudianBlog.Services.ViewModel;

namespace YudianBlog.Controllers.Controllers
{
    public class PostBaseController : Controller
    {
        private readonly ICategoryService _categoryService;

        public PostBaseController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IEnumerable<CategorySimpleView> GetCategories()
        {
            GetAllSimpleCategoryRespose response =
                                _categoryService.GetAllSimpleCategory();

            return response.CategorySimple;
        }
    }
}
