using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YudianBlog.Infrastructure.UnitOfWork;
using YudianBlog.Model.Link;

namespace YudianBlog.Repository.NHibernate.Repositories
{
    public class LinkRepository : Repository<LinkInfo, int>, ILinkRepository
    {
        public LinkRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }
    }
}
