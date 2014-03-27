using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using YudianBlog.Infrastructure.UnitOfWork;
using YudianBlog.Model.User;

namespace YudianBlog.Repository.NHibernate.Repositories
{
    public class UsersRepository : Repository<UserInfo, int>, IUserRepository
    {
        public UsersRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public override void AppendCriteria(ICriteria criteria)
        {
            criteria.CreateAlias("", "");
        }
    }
}
