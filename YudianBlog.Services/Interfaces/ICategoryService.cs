using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YudianBlog.Services.Messaging.Category;

namespace YudianBlog.Services.Interfaces
{
    public interface ICategoryService
    {
        GetAllSimpleCategoryRespose GetAllSimpleCategory();
    }
}
