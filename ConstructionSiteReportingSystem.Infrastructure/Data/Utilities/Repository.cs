using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ConstructionSiteReportingSystem.Infrastructure.Data.Utilities
{
    /// <summary>
    /// Implements the IRepository interface and provides Unit of Work pattern functionality.
    /// </summary>
    public class Repository : IRepository
    {
        private readonly DbContext _context;

        public Repository(ConstructionSiteDbContext context)
        {
            _context = context;
        }

        public void Add<TEntity>(TEntity entity) where TEntity : class
        {
            DbSet<TEntity>().Add(entity);
        }

        public async Task AddAsync<TEntity>(TEntity entity) where TEntity : class
        {
            await DbSet<TEntity>().AddAsync(entity);
        }

        public IQueryable<TEntity> All<TEntity>() where TEntity : class
        {
            return DbSet<TEntity>();
        }

        public IQueryable<TEntity> AllReadOnly<TEntity>() where TEntity : class
        {
            return DbSet<TEntity>().AsNoTracking();
        }

        public void Delete<TEntity>(TEntity entityToDelete) where TEntity : class
        {
            DbSet<TEntity>().Remove(entityToDelete);
        }

        public void DeleteRange<TEntity>(params TEntity[] entitiesToDelete) where TEntity : class
        {
            DbSet<TEntity>().RemoveRange(entitiesToDelete);
        }

		public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

		public async Task<TEntity?> GetByIdAsync<TEntity>(object id) where TEntity : class
		{
            return await DbSet<TEntity>().FindAsync(id);
		}

		private DbSet<TEntity> DbSet<TEntity>() where TEntity : class
        {
            return _context.Set<TEntity>();
        }
    }
}
