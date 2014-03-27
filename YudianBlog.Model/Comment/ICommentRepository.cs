#region

using YudianBlog.Infrastructure.Domain;

#endregion

namespace YudianBlog.Model.Comment
{
    public interface ICommentRepository:IReadOnlyRepository<CommentInfo,int>
    {
    }
}
