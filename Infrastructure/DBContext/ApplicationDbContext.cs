using Infrastructure.Core;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DBContext
{

    public partial class ApplicationDbContext : DbContext, IDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ////dynamically load all entity and query type configurations
            //var typeConfigurations = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes())
            //    .Where(type => !string.IsNullOrEmpty(type.Namespace))
            //    .Where(type => type.BaseType != null && type.BaseType.IsGenericType
            //    && type.BaseType.GetGenericTypeDefinition() == typeof(NoisEntityTypeConfiguration<>));
            //foreach (var typeConfiguration in typeConfigurations)
            //{
            //    var configuration = (IMappingConfiguration)Activator.CreateInstance(typeConfiguration);
            //    configuration.ApplyConfiguration(modelBuilder);
            //}

            base.OnModelCreating(modelBuilder);
        }
        public virtual new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }
    }

}
