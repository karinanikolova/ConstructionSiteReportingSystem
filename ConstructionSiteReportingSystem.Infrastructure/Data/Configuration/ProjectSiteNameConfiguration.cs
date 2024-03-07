using ConstructionSiteReportingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConstructionSiteReportingSystem.Infrastructure.Data.Configuration
{
    internal class ProjectSiteNameConfiguration : IEntityTypeConfiguration<ProjectSiteName>
    {
        public void Configure(EntityTypeBuilder<ProjectSiteName> builder)
        {
            // Applying query filer to the entity in order for Entity Framework Core to ignore soft-deleted records when executing queries. The query filer will only show entities with the IsDeleted property set to 'false'.
            builder.HasQueryFilter(c => c.IsDeleted == false);

            // Seeding data for ProjectSiteNames
            var data = new DataSeed();

            builder.HasData(new List<ProjectSiteName>(data.ProjectSiteNames));
        }
    }
}
