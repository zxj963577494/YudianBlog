using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YudianBlog.Services.Messaging.User;

namespace YudianBlog.Services.Interfaces
{
    public interface IUserService
    {
        GetUserDetailRespose GetUserDetail();

        GetUserSimpleRespose GetUserSimple();
    }
}
