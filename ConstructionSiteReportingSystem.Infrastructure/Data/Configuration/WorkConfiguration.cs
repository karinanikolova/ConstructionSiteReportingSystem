﻿using ConstructionSiteReportingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConstructionSiteReportingSystem.Infrastructure.Data.Configuration
{
    internal class WorkConfiguration : IEntityTypeConfiguration<Work>
    {
        public void Configure(EntityTypeBuilder<Work> builder)
        {
            // Defining table keys, relations and DeleteBehaviors
            builder
                .HasOne(w => w.WorkType)
                .WithMany(w => w.Works)
                .HasForeignKey(w => w.WorkTypeId)
                .OnDelete(DeleteBehavior.Restrict);

			builder
				.HasOne(w => w.Site)
				.WithMany(w => w.Works)
				.HasForeignKey(w => w.SiteId)
				.OnDelete(DeleteBehavior.Restrict);

			builder
                .HasOne(w => w.Stage)
                .WithMany(w => w.Works)
                .HasForeignKey(w => w.StageId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(w => w.Contractor)
                .WithMany(w => w.Works)
                .HasForeignKey(w => w.ContractorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(w => w.Unit)
                .WithMany(w => w.Works)
                .HasForeignKey(w => w.UnitId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seeding data for Works
            var data = new DataSeed();

            builder.HasData(new List<Work>(data.Works));
        }
    }
}