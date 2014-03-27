#region

using YudianBlog.Infrastructure.Domain;

#endregion

namespace YudianBlog.Model.Post
{
    public interface IPostRepository : IReadOnlyRepository<PostInfo, int>
    {

    }
}
