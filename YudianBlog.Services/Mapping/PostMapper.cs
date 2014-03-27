using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using YudianBlog.Model.Post;
using YudianBlog.Services.Messaging.Post;
using YudianBlog.Services.ViewModel;

namespace YudianBlog.Services.Mapping
{
    public static class PostMapper
    {
        /// <summary>
        /// 列表类型之间的映射,普通转换
        /// </summary>
        /// <param name="posts"></param>
        /// <returns></returns>
        public static IEnumerable<PostSimpleView> ConvertToPostSimpleView(
                                              this IEnumerable<PostInfo> posts)
        {
            return Mapper.Map<IEnumerable<PostInfo>,
                IEnumerable<PostSimpleView>>(posts);
        }


        public static IEnumerable<PostListView> ConvertToPostListView(
                                              this IEnumerable<PostInfo> posts)
        {
            return Mapper.Map<IEnumerable<PostInfo>,
                IEnumerable<PostListView>>(posts);
        }

        public static PostDetailView ConvertToPostDetailView(this 
                                               PostInfo posts)
        {
            return Mapper.Map<PostInfo, PostDetailView>(posts);
        }

        public static GetPostByCategoryRespose CreatePostSearchResultFrom(this IEnumerable<PostInfo> postInfos,
            GetPostByCategoryRequest request)
        {
            //创建返回类
            GetPostByCategoryRespose respose = new GetPostByCategoryRespose();

            //类别Id
            respose.SelectCategory = request.CategoryId;
            //类别名称
            //respose.SelectCategoryName = postInfos.Select(p => p.CategoryInfo.FirstOrDefault(c => c.Category_id == request.CategoryId))
            //    .Select(c => c.Category_name).ToString();
            //文章总数
            respose.NumberOfTitlesFound = postInfos.Count();
            //总页数
            respose.TotalNumberOfPages = NoOfResultPagesGiven(request.NumberOfResultsPerPage,
                                                                            respose.NumberOfTitlesFound);
            //文章列表视图
            respose.PostList = CropProductListToSatisfyGivenIndex(request.Index, request.NumberOfResultsPerPage, postInfos);
            return respose;
        }

        /// <summary>
        /// 计算总页数
        /// </summary>
        /// <param name="numberOfResultsPerPage">每页显示的记录数</param>
        /// <param name="numberOfTitlesFound">记录总数</param>
        /// <returns></returns>
        private static int NoOfResultPagesGiven(int numberOfResultsPerPage, int numberOfTitlesFound)
        {
            if (numberOfTitlesFound < numberOfResultsPerPage)
            {
                return 1;
            }
            else
            {
                return (numberOfTitlesFound / numberOfResultsPerPage) + (numberOfTitlesFound % numberOfResultsPerPage);
            }
        }

        /// <summary>
        /// 计算分页
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="numberOfResultsPerPage">每页显示的记录数</param>
        /// <param name="postFound"></param>
        /// <returns></returns>
        private static IEnumerable<PostListView> CropProductListToSatisfyGivenIndex(int pageIndex, int numberOfResultsPerPage, IEnumerable<PostInfo> postFound)
        {
            if (pageIndex > 1)
            {
                int numToSkip = (pageIndex - 1) * numberOfResultsPerPage;
                return postFound.Skip(numToSkip).Take(numberOfResultsPerPage).ConvertToPostListView();
                
            }
            else
            {
                return postFound.Take(numberOfResultsPerPage).ConvertToPostListView();
            }
        }
    }
}
