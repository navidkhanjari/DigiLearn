using BlogModule.Domain;
using Common.Domain.Repository;

namespace BlogModule.Repositories.Categories
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        void Delete(Category category);
        Task<List<Category>> GetAllAsync();
    }
}
