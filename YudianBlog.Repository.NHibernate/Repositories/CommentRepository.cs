using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YudianBlog.Infrastructure.UnitOfWork;
using YudianBlog.Model.Comment;

namespace YudianBlog.Repository.NHibernate.Repositories
{
    public class CommentRepository : Repository<CommentInfo, int>, ICommentRepository
    {
        public CommentRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }
    }
}
