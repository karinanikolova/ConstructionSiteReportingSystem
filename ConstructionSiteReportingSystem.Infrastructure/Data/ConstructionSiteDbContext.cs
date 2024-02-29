using ConstructionSiteReportingSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ConstructionSiteReportingSystem.Infrastructure.Data
{
    public class ConstructionSiteDbContext : IdentityDbContext
    {
        public ConstructionSiteDbContext(DbContextOptions<ConstructionSiteDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SiteStage>()
                .HasKey(ss => new { ss.SiteId, ss.StageId});

            base.OnModelCreating(builder);
        }
    }
}
