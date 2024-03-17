using Infrastructure.Core;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DBContext
{
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
    }
}
