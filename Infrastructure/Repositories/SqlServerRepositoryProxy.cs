using Infrastructure.Core;
using Infrastructure.Repositories;

namespace Infrastructure
{
    public class SqlServerRepositoryProxy<T> : IRepository<T> where T : BaseEntity
    {
        private readonly SqlServerRepository<T> _sqlServerRepository;

        public SqlServerRepositoryProxy(SqlServerRepository<T> sqlServerRepository)
        {
            this._sqlServerRepository = sqlServerRepository;
        }

        public IQueryable<T> Table => _sqlServerRepository.Table;

        public IQueryable<T> TableNoTracking => _sqlServerRepository.TableNoTracking;

        public Task<T> CreateAsync(T entity)
        {
            return _sqlServerRepository.CreateAsync(entity);
        }

        public Task DeleteAsync(string id)
        {
            return _sqlServerRepository.DeleteAsync(id);
        }

        public Task<List<T>> GetAllAsync()
        {
            return _sqlServerRepository.GetAllAsync();
        }

        public Task<T> GetByIdAsync(string id)
        {
            if (!IsValidIdentify(id, out var actualId)) return Task.FromResult<T>(default);
            return _sqlServerRepository.GetByIdAsync(actualId);
        }

        public Task UpdateAsync(string id, T entity)
        { 
            if (!IsValidIdentify(id, out var actualId)) return Task.FromResult(false);
            return _sqlServerRepository.UpdateAsync(actualId, entity);
        }

        private bool IsValidIdentify(string id, out int actualId) => int.TryParse(id, out actualId);
    }
}
