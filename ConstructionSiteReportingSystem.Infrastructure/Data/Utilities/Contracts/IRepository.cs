namespace ConstructionSiteReportingSystem.Infrastructure.Data.Utilities.Contracts
{
    /// <summary>
    /// Interface to provide implementation for a single database context use across multiple services (Unit of Work pattern). It gives a layer of abstraction between the data access layer and the business logic layer and makes it easier in case of changing database providers over time.
    /// </summary>
    public interface IRepository
    {
        IQueryable<TEntity> All<TEntity>() where TEntity : class;

        IQueryable<TEntity> AllReadOnly<TEntity>() where TEntity : class;

        Task AddAsync<TEntity>(TEntity entity) where TEntity : class;

        void Add<TEntity>(TEntity entity) where TEntity : class;

        Task<int> SaveChangesAsync();

        int SaveChanges();

        void Delete<TEntity>(TEntity entityToDelete) where TEntity : class;

        void DeleteRange<TEntity>(params TEntity[] entitiesToDelete) where TEntity : class;
    }
}
