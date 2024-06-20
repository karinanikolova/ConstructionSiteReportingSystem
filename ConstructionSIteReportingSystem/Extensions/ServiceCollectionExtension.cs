using ConstructionSiteReportingSystem.Core.Services;
using ConstructionSiteReportingSystem.Core.Services.Contracts;
using ConstructionSiteReportingSystem.Infrastructure.Data;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Providing methods to register services in order to declutter the Program.cs file.
    /// </summary>
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// Adds services holding business logic for the application to the specified IServiceCollection.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Adding custom services to the Inversion of Control container.
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<IConstructionSiteService, ConstructionSiteService>();
            services.AddScoped<IWorkService, WorkService>();
            services.AddScoped<ITaskService, TaskService>();

			return services;
        }

        /// <summary>
        /// Adds services for database to the specified IServiceCollection.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ConstructionSiteDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Adding Repository to the Inversion of Control container.
            services.AddScoped<IRepository, Repository>();

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

        /// <summary>
        /// Adds services for Identity to the specified IServiceCollection.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDefaultIdentity<IdentityUser>(options =>
                {
                    options.User.RequireUniqueEmail = true;
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireUppercase = true;
                })
                .AddEntityFrameworkStores<ConstructionSiteDbContext>();

            return services;
        }
    }
}