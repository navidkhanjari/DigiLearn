using BlogModule.Services.DTOs.Command;
using BlogModule.Services.DTOs.Query;
using Common.Application;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogModule.Services
{
    public interface IBlogService
    {
        #region Category 
        //Command
        Task<OperationResult> CreateCategory(BlogCreateCategoryCommand command);
        Task<OperationResult> EditCategory(BlogEditCategoryCommand command);
        Task<OperationResult> DeleteCategory(Guid categoryId);
        //Query
        Task<List<BlogCategoryDto>> GetAllCategory();
        Task<BlogCategoryDto> GetCategoryById(Guid Id);
        #endregion

        #region Post
        //Command
        Task<OperationResult> CreatePost(BlogCreatePostCommand command);
        Task<OperationResult> EditPost(BlogEditPostCommand command);
        Task<OperationResult> DeletePost(Guid postId);

        //Queries
        Task<BlogPostDto> GetPostById(Guid Id);
        #endregion
    }
}
