using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YudianBlog.Infrastructure.UnitOfWork;
using YudianBlog.Model.Option;

namespace YudianBlog.Repository.NHibernate.Repositories
{
    public class OptionsRepository : Repository<OptionInfo, int>, IOptionRepository
    {
        public OptionsRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }
    }
}
