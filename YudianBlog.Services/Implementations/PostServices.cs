using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YudianBlog.Infrastructure.Querying;
using YudianBlog.Model.Category;
using YudianBlog.Model.Post;
using YudianBlog.Services.Interfaces;
using YudianBlog.Services.Mapping;
using YudianBlog.Services.Messaging.Category;
using YudianBlog.Services.Messaging.Post;
using YudianBlog.Services.ViewModel;

namespace YudianBlog.Services.Implementations
{
    public class PostServices : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PostServices(IPostRepository postRepository,
                                       ICategoryRepository categoryRepository)
        {
            _postRepository = postRepository;
            _categoryRepository = categoryRepository;
        }


        #region 获取某分类中的文章
        /// <summary>
        /// 从数据库获取某分类中的所有文章并排序
        /// </summary>
        /// <param name="request">获取某分类中的文章 请求类</param>
        /// <param name="postsQuery">文章查询对象</param>
        /// <returns></returns>
        private IEnumerable<PostInfo> GetAllPostMatchingQueryAndSort(GetPostByCategoryRequest request, Query postsQuery)
        {
            IEnumerable<PostInfo> postsMatching = _postRepository.FindBy(postsQuery);

            switch (request.Sort)
            {
                case PostSortBy.DateTimeAsc:
                    postsMatching = postsMatching.OrderBy(p => p.Post_date);
                    break;
                case PostSortBy.DateTimeDesc:
                    postsMatching = postsMatching.OrderByDescending(p => p.Post_date);
                    break;
            }
            return postsMatching;
        }
        #endregion

        public GetFeaturePostRespose GetFeaturePost()
        {
            GetFeaturePostRespose respose = new GetFeaturePostRespose();

            Query postsQuery = new Query();

            postsQuery.OrderByProperty = new OrderByClause()
            {
                Desc = false,
                PropertyName = PropertyNameHelper.ResolvePropertyName<PostInfo>(p => p.Post_id)
            };

            respose.PostSimple = _postRepository.FindBy(postsQuery, 0, 10).ConvertToPostSimpleView();
            return respose;
        }

        public GetPostByCategoryRespose GetPostsByCategory(GetPostByCategoryRequest request)
        {
            GetPostByCategoryRespose response;

            Query productQuery = PostSearchRequestQueryGenerator.CreateQueryFor(request);

            IEnumerable<PostInfo> productsMatchingRefinement = GetAllPostMatchingQueryAndSort(request, productQuery);

            response = productsMatchingRefinement.CreatePostSearchResultFrom(request);

            if (request.CategoryId != 0)
            {
                response.SelectCategoryName =
               _categoryRepository.FindBy(request.CategoryId).Category_name;
            }
            return response;
        }

        public GetPostByIdRespose GetPostById(GetPostByIdRequest request)
        {
            GetPostByIdRespose response = new GetPostByIdRespose();

            PostInfo postInfos = _postRepository.FindBy(request.PostId);

            response.PostsDetail = postInfos.ConvertToPostDetailView();

            return response;
        }
    }
}
