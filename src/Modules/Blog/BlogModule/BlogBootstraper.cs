using BlogModule.Context;
using BlogModule.Repositories.Categories;
using BlogModule.Repositories.Posts;
using BlogModule.Services;
using Common.Application.FileUtil.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BlogModule
{
    public static class BlogBootstraper
    {
        public static IServiceCollection InitBlogModule(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<BlogContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("Blog_Context"));
            });

            #region Repositories
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IPostRepository, PostRepository>();

            #endregion

            #region services
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<ILocalFileService, ILocalFileService>();
            #endregion

            services.AddAutoMapper(typeof(MapperProfile).Assembly);

            return services;
        }
    }
}
