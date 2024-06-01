using Common.Domain;
using Common.Domain.Repository;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Common.Infrastructure.Repository
{
    public class MongoRepository<TEntity, TContext> : IMongoRepository<TEntity> where TEntity : BaseEntity where TContext : BaseMongoContext
    {
        protected readonly IMongoCollection<TEntity> Collection;
        public MongoRepository(TContext context)
        {
            var dataBase = context.GetDataBase();
            Collection = dataBase.GetCollection<TEntity>(GenerateCollectionName(typeof(TEntity).Name));
        }

        public async Task DeleteAsync(Guid id)
        {
            await Collection.DeleteOneAsync(f => f.Id == id);
        }
        public async Task DeleteRangeAsync(FilterDefinition<TEntity> filter)
        {
            await Collection.DeleteManyAsync(filter);
        }
        public async Task<List<TEntity>> GetAllAsync()
        {
            var res = await Collection.FindAsync(r => true);
            return res.ToList();
        }
        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            var res = await Collection.FindAsync(f => f.Id == id);
            return res.FirstOrDefault();
        }
        public async Task InsertAsync(TEntity entity)
        {
            await Collection.InsertOneAsync(entity);
        }
        public async Task UpdateAsync(TEntity entity)
        {
            await Collection.ReplaceOneAsync(f => f.Id == entity.Id, entity);
        }

        public async Task<bool> IsExist(Expression<Func<TEntity, bool>> expression)
        {
            var entity = await Collection.FindAsync(expression);
            return entity.FirstOrDefault() != null;
        }


        protected string GenerateCollectionName(string entityName)
        {
            if (entityName.EndsWith("i"))
                entityName = entityName.Substring(0, entityName.Length - 1) + "es";
            else if (entityName.EndsWith("y"))
                entityName = entityName.Substring(0, entityName.Length - 1) + "ies";
            else
                entityName += "s";
            return entityName;
        }
    }
}
