using AutoMapper;
using BlogModule.Domain;
using BlogModule.Repositories.Categories;
using BlogModule.Repositories.Posts;
using BlogModule.Services.DTOs.Command;
using BlogModule.Services.DTOs.Query;
using BlogModule.Utils;
using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Common.Application.SecurityUtil;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogModule.Services
{
    class BlogService : IBlogService
    {
        #region DI
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPostRepository _postRepository;
        private readonly ILocalFileService _localFileService;
        private readonly IMapper _mapper;
        public BlogService(ICategoryRepository categoryRepository, IMapper mapper,IPostRepository postRepository, ILocalFileService localFileService)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _postRepository = postRepository;
            _localFileService = localFileService;
            
        }
        #endregion

        #region Category
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

            if (command.Slug != category.Slug)
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
        public async Task<BlogCategoryDto> GetCategoryById(Guid Id)
        {
            var category = await _categoryRepository.GetAsync(Id);
            return _mapper.Map<BlogCategoryDto>(category);
        }
        public async Task<List<BlogCategoryDto>> GetAllCategory()
        {
            var categories = await _categoryRepository.GetAllAsyc();

            return _mapper.Map<List<BlogCategoryDto>>(categories);
        }

        #endregion

        #region Post
        public async Task<OperationResult> CreatePost(BlogCreatePostCommand command)
        {
            var post = _mapper.Map<Post>(command);

            if (await _postRepository.ExistsAsync(p => p.Slug == post.Slug))
                return OperationResult.Error("Slug Is Exist");

            if (command.ImageFile.IsImage() == false)
                return OperationResult.Error("تصویر وارد شده نامعتبر است");

            var imageName = await _localFileService.SaveFileAndGenerateName(command.ImageFile,BlogDirectories.PostImage);
            post.ImageName = imageName;
            post.Visit = 1;
            post.Descriptions = post.Descriptions.SanitizeText();

            _postRepository.Add(post);

            await _postRepository.Save();
            return OperationResult.Success();
        }

        public async Task<OperationResult> EditPost(BlogEditPostCommand command)
        {
            var post = await _postRepository.GetTracking(command.Id);
            if (post == null) return OperationResult.NotFound();

            if (post.Slug != command.Slug)
                if (await _postRepository.ExistsAsync(f => f.Slug == command.Slug))
                    return OperationResult.Error("Slug is Exist");

            if (command.ImageFile != null)
                if (command.ImageFile.IsImage() == false)
                    return OperationResult.Error("عکس وارد شده نامعتبر است");
                else
                {
                    var imageName = await _localFileService.SaveFileAndGenerateName(command.ImageFile, BlogDirectories.PostImage);
                    post.ImageName = imageName;
                }

            post.Descriptions = command.Descriptions.SanitizeText();
            post.OwnerName = command.OwnerName;
            post.Title = command.Title;
            post.CategoryId = command.CategoryId;
            post.UserId = command.UserId;
            post.Slug = command.Slug;

            _postRepository.Update(post);
            await _postRepository.Save();
            return OperationResult.Success();
        }

        public async Task<OperationResult> DeletePost(Guid postId)
        {
            var post = await _postRepository.GetAsync(postId);
            if (post == null)
                return OperationResult.NotFound();

            post.IsDelete = true;

            _postRepository.Update(post);
            await _postRepository.Save();

            return OperationResult.Success();

        }

        public async Task<BlogPostDto> GetPostById(Guid Id)
        {
            var post = await _postRepository.GetAsync(Id);
            if (post == null)
                return null;

            return _mapper.Map<BlogPostDto>(post);
        }
        #endregion
    }
}
