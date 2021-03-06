﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using YudianBlog.Infrastructure.UnitOfWork;
using YudianBlog.Model.Post;

namespace YudianBlog.Repository.NHibernate.Repositories
{
    public class PostRepository : Repository<PostInfo, int>, IPostRepository
    {
        public PostRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public override void AppendCriteria(ICriteria criteria)
        {
            criteria.CreateAlias("CategoryInfo", "Category");
        }
    }
}
