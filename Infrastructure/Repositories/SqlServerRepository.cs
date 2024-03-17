using Infrastructure.Core;
using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class SqlServerRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IDbContext _context;
        private DbSet<T> _entities;

        public SqlServerRepository(IDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Table => _entities ??= _context.Set<T>();

        public IQueryable<T> TableNoTracking => _context.Set<T>().AsNoTracking();

        public async Task<T> CreateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(int id, T entity)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(string id, T entity)
        {
            throw new NotImplementedException();
        }

    }
}
