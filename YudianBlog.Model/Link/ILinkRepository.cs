#region

using YudianBlog.Infrastructure.Domain;

#endregion

namespace YudianBlog.Model.Link
{
    public interface ILinkRepository : IReadOnlyRepository<LinkInfo, int>
    {

    }

}