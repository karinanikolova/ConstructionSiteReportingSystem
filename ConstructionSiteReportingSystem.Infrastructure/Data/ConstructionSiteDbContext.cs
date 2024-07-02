using ConstructionSiteReportingSystem.Infrastructure.Data.Configuration;
using ConstructionSiteReportingSystem.Infrastructure.Data.Models;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities.Contracts;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Task = ConstructionSiteReportingSystem.Infrastructure.Data.Models.Task;

namespace ConstructionSiteReportingSystem.Infrastructure.Data
{
    public class ConstructionSiteDbContext : IdentityDbContext<ApplicationUser>
    {
        public ConstructionSiteDbContext(DbContextOptions<ConstructionSiteDbContext> options)
            : base(options)
        {

        }

        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<WorkType> WorksTypes { get; set; }

        // Overriding the SaveChanges method in order to achieve soft delete
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        // Overriding the SaveChangesAsync method in order to achieve soft delete.
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Applying configurations for each entity, including query filters, defining table keys, relations and DeleteBehaviors
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserClaimsConfiguration());
            builder.ApplyConfiguration(new ContractorConfiguration());
            builder.ApplyConfiguration(new SiteConfiguration());
            builder.ApplyConfiguration(new StageConfiguration());
            builder.ApplyConfiguration(new UnitConfiguration());
            builder.ApplyConfiguration(new WorkTypeConfiguration());
            builder.ApplyConfiguration(new WorkConfiguration());
            builder.ApplyConfiguration(new TaskConfiguration());

            base.OnModelCreating(builder);
        }

        /// <summary>
        /// Implements logic of what the Change tracker should do when running into tracked objects which are marked as ‘Deleted’. The objects initially marked as ‘Deleted’ are instead marked as ‘Modified’ and their IsDeleted property – set to true. These objects' DeletedAt property is assigned a DateTimeOffset object whose date and time are set to the current Coordinated Universal Time (UTC) date and time.
        /// </summary>
        private void OnBeforeSaving()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Deleted && entry.Entity is ISoftDelete)
                {
                    entry.State = EntityState.Modified;

                    entry.CurrentValues["IsDeleted"] = true;
                    entry.CurrentValues["DeletedAt"] = DateTimeOffset.UtcNow;
                }
            }
        }
    }
}
