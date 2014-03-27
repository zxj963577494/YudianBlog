using System.Collections.Generic;
using YudianBlog.Services.ViewModel;

namespace YudianBlog.Controllers.ViewModels.Post
{
    public abstract class BasePostPageView : BasePageView
    {
        public IEnumerable<CategorySimpleView> Categories { get; set; }
    }
}
