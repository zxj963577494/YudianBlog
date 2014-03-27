using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YudianBlog.Model.Category;
using YudianBlog.Services.Interfaces;
using YudianBlog.Services.Mapping;
using YudianBlog.Services.Messaging.Category;

namespace YudianBlog.Services.Implementations
{
    public class CategoryService:ICategoryService
    {
        private ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public GetAllSimpleCategoryRespose GetAllSimpleCategory()
        {
            GetAllSimpleCategoryRespose response = new GetAllSimpleCategoryRespose();
            IEnumerable<CategoryInfo> categories = _categoryRepository.FindAll();
            response.CategorySimple = categories.ConvertToCategorySimpleView();

            return response;
        }
    }
}
