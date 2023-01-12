using BlogModule.Context;
using BlogModule.Domain;
using Common.Infrastructure.Repository;


namespace BlogModule.Repositories.Categories
{
    class CategoryRepository : BaseRepository<Category, BlogContext>, ICategoryRepository
    {
        public CategoryRepository(BlogContext context) : base(context)
        {

        }
    }
}
