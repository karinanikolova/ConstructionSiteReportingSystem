using ConstructionSiteReportingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConstructionSiteReportingSystem.Infrastructure.Data.Configuration
{
    internal class WorkByProjectConfiguration : IEntityTypeConfiguration<WorkByProject>
    {
        public void Configure(EntityTypeBuilder<WorkByProject> builder)
        {
            // Defining table keys, relations and DeleteBehaviors
            builder
                .HasOne(wbp => wbp.Project)
                .WithMany(wbp => wbp.WorksByProjects)
                .HasForeignKey(wbp => wbp.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(wbp => wbp.Unit)
                .WithMany(wbp => wbp.WorksByProjects)
                .HasForeignKey(wbp => wbp.UnitId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(wbp => wbp.WorkType)
                .WithMany(wbp => wbp.WorksByProjects)
                .HasForeignKey(wbp => wbp.WorkTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Applying query filer to the entity in order for Entity Framework Core to ignore soft-deleted records when executing queries. The query filer will only show entities with the IsDeleted property set to 'false'.
            builder.HasQueryFilter(c => c.IsDeleted == false);

            // Seeding data for WorksByProjects
            var data = new DataSeed();

            builder.HasData(new List<WorkByProject>(data.WorksByProjects));
        }
    }
}
