using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YudianBlog.Model.User;
using YudianBlog.Services.Interfaces;
using YudianBlog.Services.Mapping;
using YudianBlog.Services.Messaging.User;
using YudianBlog.Services.ViewModel;

namespace YudianBlog.Services.Implementations
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Messaging.User.GetUserDetailRespose GetUserDetail()
        {
            GetUserDetailRespose respose = new GetUserDetailRespose();
            UserInfo userInfos = _userRepository.FindBy(1);
            respose.UserDetail = userInfos.ConvertToUserDetailView();
            return respose;
        }

        public Messaging.User.GetUserSimpleRespose GetUserSimple()
        {
            GetUserSimpleRespose respose = new GetUserSimpleRespose();
            UserInfo userInfos = _userRepository.FindBy(1);
            respose.UserSimple = userInfos.ConvertToUserSimpleView();
            return respose;
        }
    }
}
