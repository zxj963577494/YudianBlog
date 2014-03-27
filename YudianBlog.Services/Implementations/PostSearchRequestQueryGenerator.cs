using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YudianBlog.Infrastructure.Querying;
using YudianBlog.Model.Category;
using YudianBlog.Model.Post;
using YudianBlog.Services.Messaging.Post;

namespace YudianBlog.Services.Implementations
{
    public class PostSearchRequestQueryGenerator
    {
        /// <summary>
        /// 组合查询条件
        /// </summary>
        /// <param name="getProductsByCategoryRequest"></param>
        /// <returns></returns>
        public static Query CreateQueryFor(
                           GetPostByCategoryRequest getProductsByCategoryRequest)
        {
            Query postQuery = new Query();
            Query postCommentStatusQuery = new Query();
            Query postStatusQuery = new Query();
            Query postTypeQuery = new Query();

            #region PostCommentStatus 文章评论状态比较

            postCommentStatusQuery.QueryOperator = QueryOperator.And;

            postCommentStatusQuery.Add(Criterion.Create<PostInfo>(p => p.Post_comment_status, getProductsByCategoryRequest.PostCommentStatus,
                CriteriaOperator.Equal));

            if (postCommentStatusQuery.Criteria.Any())
            {
                postQuery.AddSubQuery(postCommentStatusQuery);
            }
            #endregion

            #region PostStatus 文章状态比较

            postStatusQuery.QueryOperator = QueryOperator.And;

            postStatusQuery.Add(Criterion.Create<PostInfo>(p => p.Post_status, getProductsByCategoryRequest.PostStatus,
                                                           CriteriaOperator.Equal));

            if (postStatusQuery.Criteria.Any())
            {
                postQuery.AddSubQuery(postStatusQuery);
            }

            #endregion

            #region PostType 文章类型比较

            postTypeQuery.QueryOperator = QueryOperator.And;

            postTypeQuery.Add(Criterion.Create<PostInfo>(p => p.Post_type, getProductsByCategoryRequest.PostType,
                                                           CriteriaOperator.Equal));

            if (postTypeQuery.Criteria.Any())
                postQuery.AddSubQuery(postTypeQuery);
            #endregion

            #region 类别Id比较

            if (getProductsByCategoryRequest.CategoryId != 0)
            {
                postQuery.Add(Criterion.Create<PostInfo>("Category.Category_id",
                  getProductsByCategoryRequest.CategoryId, CriteriaOperator.Equal));
            }
            #endregion

            return postQuery;
        }
    }
}
