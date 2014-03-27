using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using YudianBlog.Infrastructure.UnitOfWork;
using YudianBlog.Model.Category;
using YudianBlog.Model.Post;

namespace YudianBlog.Repository.NHibernate.Repositories
{
    public class CategoryRepository : Repository<CategoryInfo, int>, ICategoryRepository
    {
        public CategoryRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public override void AppendCriteria(ICriteria criteria)
        {
          
        }
    }
}
