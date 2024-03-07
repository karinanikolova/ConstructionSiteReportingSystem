using ConstructionSiteReportingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConstructionSiteReportingSystem.Infrastructure.Data.Configuration
{
    internal class SiteStageConfiguration : IEntityTypeConfiguration<SiteStage>
    {
        public void Configure(EntityTypeBuilder<SiteStage> builder)
        {
            // Defining table keys, relations and DeleteBehaviors
            builder.HasKey(ss => new { ss.SiteId, ss.StageId });

            builder
                .HasOne(ss => ss.Site)
                .WithMany(ss => ss.SitesStages)
                .HasForeignKey(ss => ss.SiteId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(ss => ss.Stage)
                .WithMany(ss => ss.SitesStages)
                .HasForeignKey(ss => ss.StageId)
                .OnDelete(DeleteBehavior.Restrict);

            // Applying query filer to the entity in order for Entity Framework Core to ignore soft-deleted records when executing queries. The query filer will only show entities with the IsDeleted property set to 'false'.
            builder.HasQueryFilter(c => c.IsDeleted == false);

            // Seeding data for SitesStages
            var data = new DataSeed();

            builder.HasData(new List<SiteStage>(data.SitesStages));
        }
    }
}
