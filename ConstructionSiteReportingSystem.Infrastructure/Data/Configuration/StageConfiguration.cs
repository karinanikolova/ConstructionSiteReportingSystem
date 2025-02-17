using ConstructionSiteReportingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConstructionSiteReportingSystem.Infrastructure.Data.Configuration
{
    internal class StageConfiguration : IEntityTypeConfiguration<Stage>
    {
        public void Configure(EntityTypeBuilder<Stage> builder)
        {
            // Seeding data for Stages
            var data = new DataSeed();

            builder.HasData(new List<Stage>(data.Stages));
        }
    }
}