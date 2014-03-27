#region

using YudianBlog.Infrastructure.Domain;

#endregion

namespace YudianBlog.Model.Category
{
    public interface ICategoryRepository : IReadOnlyRepository<CategoryInfo, int>
    {
    }
}
