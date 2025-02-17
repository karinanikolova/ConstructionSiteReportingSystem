using ConstructionSiteReportingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConstructionSiteReportingSystem.Infrastructure.Data.Configuration
{
    internal class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            // Seeding data for Units
            var data = new DataSeed();

            builder.HasData(new List<Unit>(data.Units));
        }
    }
}