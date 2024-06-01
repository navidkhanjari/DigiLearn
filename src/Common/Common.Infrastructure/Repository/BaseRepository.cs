using Common.Domain;
using Common.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Common.Infrastructure.Repository
{
    public class BaseRepository<T, TContext> : IBaseRepository<T>
    where TContext : DbContext where T : BaseEntity
    {
        protected readonly TContext Context;
        public BaseRepository(TContext context)
        {
            Context = context;
        }
        public async Task<T?> GetAsync(Guid id)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(t => t.Id.Equals(id));
        }
        public async Task<T?> GetTracking(Guid id)
        {
            return await Context.Set<T>().AsTracking().FirstOrDefaultAsync(t => t.Id.Equals(id));
        }
        public T? Get(Guid id)
        {
            return Context.Set<T>().FirstOrDefault(t => t.Id.Equals(id));
        }
        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }
        public async Task AddAsync(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
        }
        public async Task AddRangeAsync(ICollection<T> entities)
        {
            await Context.Set<T>().AddRangeAsync(entities);
        }
        public void Update(T entity)
        {
            Context.Update(entity);
        }
        public async Task<int> SaveAsync()
        {
            return await Context.SaveChangesAsync();
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public async Task<bool> ExistAsync(Expression<Func<T, bool>> expression)
        {
            return await Context.Set<T>().AnyAsync(expression);
        }
        public bool Exist(Expression<Func<T, bool>> expression)
        {
            return Context.Set<T>().Any(expression);
        }

    }
}
