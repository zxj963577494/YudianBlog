using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YudianBlog.Model.Post
{
    public class CategoryPostLink
    {
        public virtual object Object_id
        {
            get;
            set;
        }

        public virtual object Categorys_id
        {
            get;
            set;
        }

    }
}
