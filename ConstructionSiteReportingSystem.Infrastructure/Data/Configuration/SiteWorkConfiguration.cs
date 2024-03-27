using ConstructionSiteReportingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConstructionSiteReportingSystem.Infrastructure.Data.Configuration
{
    internal class SiteWorkConfiguration : IEntityTypeConfiguration<SiteWork>
    {
        public void Configure(EntityTypeBuilder<SiteWork> builder)
        {
            // Defining table keys, relations and DeleteBehaviors
            builder.HasKey(ss => new { ss.SiteId, ss.WorkId });

            builder
                .HasOne(ss => ss.Site)
                .WithMany(ss => ss.SitesWorks)
                .HasForeignKey(ss => ss.SiteId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(ss => ss.Work)
                .WithMany(ss => ss.SitesWorks)
                .HasForeignKey(ss => ss.WorkId)
                .OnDelete(DeleteBehavior.Restrict);

            // Applying query filer to the entity in order for Entity Framework Core to ignore soft-deleted records when executing queries. The query filer will only show entities with the IsDeleted property set to 'false'.
            builder.HasQueryFilter(c => c.IsDeleted == false);

            // Seeding data for SitesWorks
            var data = new DataSeed();

            builder.HasData(new List<SiteWork>(data.SitesWorks));
        }
    }
}
