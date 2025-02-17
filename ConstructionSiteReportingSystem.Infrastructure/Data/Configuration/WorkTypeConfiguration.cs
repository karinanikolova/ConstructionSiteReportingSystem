using ConstructionSiteReportingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConstructionSiteReportingSystem.Infrastructure.Data.Configuration
{
    internal class WorkTypeConfiguration : IEntityTypeConfiguration<WorkType>
    {
        public void Configure(EntityTypeBuilder<WorkType> builder)
        {
            // Seeding data for WorkTypes
            var data = new DataSeed();

            builder.HasData(new List<WorkType>(data.WorkTypes));
        }
    }
}