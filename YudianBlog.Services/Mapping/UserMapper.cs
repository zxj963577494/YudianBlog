

using AutoMapper;
using YudianBlog.Model.User;
using YudianBlog.Services.ViewModel;

namespace YudianBlog.Services.Mapping
{
    public static class UserMapper
    {
        public static UserSimpleView ConvertToUserSimpleView(this 
                                               UserInfo user)
        {
            return Mapper.Map<UserInfo, UserSimpleView>(user);
        }

        public static UserDetailView ConvertToUserDetailView(this 
                                               UserInfo user)
        {
            return Mapper.Map<UserInfo, UserDetailView>(user);
        }
    }
}
