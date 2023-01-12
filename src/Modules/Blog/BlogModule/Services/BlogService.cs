using AutoMapper;
using BlogModule.Domain;
using BlogModule.Repositories.Categories;
using BlogModule.Services.DTOs.Command;
using BlogModule.Services.DTOs.Query;
using Common.Application;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogModule.Services
{
    class BlogService : IBlogService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public BlogService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task<OperationResult> CreateCategory(BlogCreateCategoryCommand command)
        {
            var category = _mapper.Map<Category>(command);
            if (await _categoryRepository.ExistsAsync(f => f.Slug == category.Slug))
            {
                return OperationResult.Error("Slug is Exist");
            }
            _categoryRepository.Add(category);
            await _categoryRepository.Save();
            return OperationResult.Success();
        }

        public async Task<OperationResult> DeleteCategory(Guid categoryId)
        {
            var category = await _categoryRepository.GetAsync(categoryId);
            if (category == null)
                return OperationResult.NotFound();

            category.IsDelete = true;

            await _categoryRepository.Save();

            return OperationResult.Success();
        }

        public async Task<OperationResult> EditCategory(BlogEditCategoryCommand command)
        {
            var category = await _categoryRepository.GetAsync(command.Id);
            if (category == null)
                return OperationResult.NotFound();

            if(command.Slug != category.Slug)
            {
                if (await _categoryRepository.ExistsAsync(f => f.Slug == category.Slug))
                    return OperationResult.Error("Slug is Exist");
            }

            category.Slug = command.Slug;
            category.Title = command.Title;

            _categoryRepository.Update(category);
            await _categoryRepository.Save();
            return OperationResult.Success();
        }

        public async Task<List<BlogCategoryDto>> GetAllCategory()
        {
            var categories = await _categoryRepository.GetAllAsyc();

            return _mapper.Map<List<BlogCategoryDto>>(categories);
        }

        public async Task<BlogCategoryDto> GetCategoryById(Guid Id)
        {
            var category = await _categoryRepository.GetAsync(Id);
            return _mapper.Map<BlogCategoryDto>(category);
        }
    }
}
