using ConstructionSiteReportingSystem.Infrastructure.Data.Models;
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
        public DbSet<ProjectSiteInfo> ProjectsSitesInfo { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<SiteStage> SitesStages { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<WorkByProject> WorksByProjects { get; set; }
        public DbSet<WorkInfo> WorksInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SiteStage>()
                .HasKey(ss => new { ss.SiteId, ss.StageId});

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
                .HasOne(wbp => wbp.WorkInfo)
                .WithMany(wbp => wbp.WorksByProjects)
                .HasForeignKey(wbp => wbp.WorkInfoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Work>()
                .HasOne(w => w.WorkInfo)
                .WithMany(w => w.Works)
                .HasForeignKey(w => w.WorkInfoId)
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
    }
}
