using ConstructionSiteReportingSystem.Infrastructure.Data.Configuration;
using ConstructionSiteReportingSystem.Infrastructure.Data.Models;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities.Contracts;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Task = ConstructionSiteReportingSystem.Infrastructure.Data.Models.Task;

namespace ConstructionSiteReportingSystem.Infrastructure.Data
{
	public class ConstructionSiteDbContext : IdentityDbContext<ApplicationUser>
	{
		private bool _shouldSeedDb;

		public ConstructionSiteDbContext(DbContextOptions<ConstructionSiteDbContext> options, bool shouldSeedDb = true)
			: base(options)
		{
			_shouldSeedDb = shouldSeedDb;
		}

		public DbSet<Contractor> Contractors { get; set; }
		public DbSet<Site> Sites { get; set; }
		public DbSet<Stage> Stages { get; set; }
		public DbSet<Task> Tasks { get; set; }
		public DbSet<Unit> Units { get; set; }
		public DbSet<Work> Works { get; set; }
		public DbSet<WorkType> WorksTypes { get; set; }

		// Overriding the SaveChanges method in order to achieve soft delete.
		public override int SaveChanges(bool acceptAllChangesOnSuccess)
		{
			OnBeforeSaving();

			return base.SaveChanges(acceptAllChangesOnSuccess);
		}

		// Overriding the SaveChangesAsync method in order to achieve soft delete.
		public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
		{
			OnBeforeSaving();

			return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			// 1. Calling the base OnModelCreating method in order to apply the default behavior and configurations provided by IdentityDbContext<ApplicationUser>. Therefore preventing custom configurations to be overwritten by Entity Framework Core later.
			base.OnModelCreating(builder);

			// 2. Applying custom query filters to all entities that implement ISoftDelete in order for Entity Framework Core to ignore soft-deleted records when executing queries. The query filer will only show entities with the IsDeleted property set to 'false'.
			foreach (var entityType in builder.Model.GetEntityTypes())
			{
				if (typeof(ISoftDelete).IsAssignableFrom(entityType.ClrType))
				{
					var parameter = Expression.Parameter(entityType.ClrType, "e");
					var property = Expression.Property(parameter, nameof(ISoftDelete.IsDeleted));
					var condition = Expression.Lambda(Expression.Equal(property, Expression.Constant(false)), parameter);

					builder.Entity(entityType.ClrType).HasQueryFilter(condition);
				}
			}

			// 3. Providing additional entity configurations.
			if (_shouldSeedDb)
			{
				// Applying configurations for each entity, including defining table keys, relations and DeleteBehaviors.
				builder.ApplyConfiguration(new UserConfiguration());
				builder.ApplyConfiguration(new UserClaimsConfiguration());
				builder.ApplyConfiguration(new ContractorConfiguration());
				builder.ApplyConfiguration(new SiteConfiguration());
				builder.ApplyConfiguration(new StageConfiguration());
				builder.ApplyConfiguration(new UnitConfiguration());
				builder.ApplyConfiguration(new WorkTypeConfiguration());
				builder.ApplyConfiguration(new WorkConfiguration());
				builder.ApplyConfiguration(new TaskConfiguration());
			}
		}

		/// <summary>
		/// Implements logic of what the Change tracker should do when running into tracked objects which are marked as ‘Deleted’. The objects initially marked as ‘Deleted’ are instead marked as ‘Modified’ and their IsDeleted property – set to true. These objects' DeletedAt property is assigned a DateTimeOffset object whose date and time are set to the current Coordinated Universal Time (UTC) date and time.
		/// </summary>
		private void OnBeforeSaving()
		{
			foreach (var entry in ChangeTracker.Entries())
			{
				if (entry.State == EntityState.Deleted && entry.Entity is ISoftDelete)
				{
					entry.State = EntityState.Modified;

					entry.CurrentValues["IsDeleted"] = true;
					entry.CurrentValues["DeletedAt"] = DateTimeOffset.UtcNow;
				}
			}
		}
	}
}