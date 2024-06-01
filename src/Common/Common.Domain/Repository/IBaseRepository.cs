using System.Linq.Expressions;

namespace Common.Domain.Repository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T?> GetAsync(Guid id);
        Task<T?> GetTracking(Guid id);
        T? Get(Guid id);

        Task AddAsync(T entity);
        void Add(T entity);

        Task AddRangeAsync(ICollection<T> entities);

        void Update(T entity);

        Task<int> SaveAsync();
        void Save();

        Task<bool> ExistAsync(Expression<Func<T, bool>> expression);
        bool Exist(Expression<Func<T, bool>> expression);
    }
}
