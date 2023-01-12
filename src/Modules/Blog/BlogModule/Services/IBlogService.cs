using BlogModule.Services.DTOs.Command;
using BlogModule.Services.DTOs.Query;
using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogModule.Services
{
    public interface IBlogService
    {
        //Command
        Task<OperationResult> CreateCategory(BlogCreateCategoryCommand command);
        Task<OperationResult> EditCategory(BlogEditCategoryCommand command);
        Task<OperationResult> DeleteCategory(Guid categoryId);
        //Query
        Task<List<BlogCategoryDto>> GetAllCategory();
        Task<BlogCategoryDto> GetCategoryById(Guid Id);
    }
}
