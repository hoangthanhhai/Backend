using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DBContext
{
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
