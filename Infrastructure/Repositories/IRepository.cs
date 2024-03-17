using Infrastructure.Core;

namespace Infrastructure.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> Table { get; }
        IQueryable<TEntity> TableNoTracking { get; }

        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(string id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task UpdateAsync(string id, TEntity entity);
        Task DeleteAsync(string id);
    }

}
