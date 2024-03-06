using ConstructionSiteReportingSystem.Infrastructure.Data.Models;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities.Contracts;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Task = ConstructionSiteReportingSystem.Infrastructure.Data.Models.Task;

namespace ConstructionSiteReportingSystem.Infrastructure.Data
{
    public class ConstructionSiteDbContext : IdentityDbContext
    {
        public ConstructionSiteDbContext(DbContextOptions<ConstructionSiteDbContext> options)
            : base(options)
        {

        }

        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectSiteName> ProjectsSitesNames { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<SiteStage> SitesStages { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<WorkByProject> WorksByProjects { get; set; }
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
            // Applying query filers to each entity in order for Entity Framework Core to ignore soft-deleted records when executing queries. The query filer will only show entities with the IsDeleted property set to 'false'.

            builder.Entity<Contractor>()
                .HasQueryFilter(c => c.IsDeleted == false);

            builder.Entity<Project>()
                .HasQueryFilter(c => c.IsDeleted == false);

            builder.Entity<ProjectSiteName>()
                .HasQueryFilter(c => c.IsDeleted == false);

            builder.Entity<Site>()
                .HasQueryFilter(c => c.IsDeleted == false);

            builder.Entity<SiteStage>()
                .HasQueryFilter(c => c.IsDeleted == false);

            builder.Entity<Stage>()
                .HasQueryFilter(c => c.IsDeleted == false);

            builder.Entity<Task>()
                .HasQueryFilter(c => c.IsDeleted == false);

            builder.Entity<Unit>()
                .HasQueryFilter(c => c.IsDeleted == false);

            builder.Entity<Work>()
                .HasQueryFilter(c => c.IsDeleted == false);

            builder.Entity<WorkByProject>()
                .HasQueryFilter(c => c.IsDeleted == false);

            builder.Entity<WorkType>()
                .HasQueryFilter(c => c.IsDeleted == false);

            // Defining table keys, relations and Deletebehaviors

            builder.Entity<SiteStage>()
                .HasKey(ss => new { ss.SiteId, ss.StageId });

            builder.Entity<SiteStage>()
                .HasOne(ss => ss.Site)
                .WithMany(ss => ss.SitesStages)
                .HasForeignKey(ss => ss.SiteId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<SiteStage>()
                .HasOne(ss => ss.Stage)
                .WithMany(ss => ss.SitesStages)
                .HasForeignKey(ss => ss.StageId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<WorkByProject>()
                .HasOne(wbp => wbp.Project)
                .WithMany(wbp => wbp.WorksByProjects)
                .HasForeignKey(wbp => wbp.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<WorkByProject>()
                .HasOne(wbp => wbp.Unit)
                .WithMany(wbp => wbp.WorksByProjects)
                .HasForeignKey(wbp => wbp.UnitId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<WorkByProject>()
                .HasOne(wbp => wbp.WorkType)
                .WithMany(wbp => wbp.WorksByProjects)
                .HasForeignKey(wbp => wbp.WorkTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Work>()
                .HasOne(w => w.WorkType)
                .WithMany(w => w.Works)
                .HasForeignKey(w => w.WorkTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Work>()
                .HasOne(w => w.Stage)
                .WithMany(w => w.Works)
                .HasForeignKey(w => w.StageId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Work>()
                .HasOne(w => w.Contractor)
                .WithMany(w => w.Works)
                .HasForeignKey(w => w.ContractorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Work>()
                .HasOne(w => w.Unit)
                .WithMany(w => w.Works)
                .HasForeignKey(w => w.UnitId)
                .OnDelete(DeleteBehavior.Restrict);

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
