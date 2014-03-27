#region

using YudianBlog.Infrastructure.Domain;

#endregion

namespace YudianBlog.Model.User
{
    public interface IUserRepository:IReadOnlyRepository<UserInfo,int>
    {
    }
}
