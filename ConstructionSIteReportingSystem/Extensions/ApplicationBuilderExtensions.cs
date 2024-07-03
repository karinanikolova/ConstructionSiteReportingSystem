using ConstructionSiteReportingSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using static ConstructionSiteReportingSystem.Core.Constants.AdministratorConstants;
using Task = System.Threading.Tasks.Task;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Providing a method for creating an administrator role in the application.
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static async Task CreateAdminRoleAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (userManager != null && roleManager != null && await roleManager.RoleExistsAsync(AdminRole) == false)
            {
                var adminRole = new IdentityRole(AdminRole);

                await roleManager.CreateAsync(adminRole);

                var adminUser = await userManager.FindByEmailAsync(AdminEmail);

                if ( adminUser != null )
                {
                    await userManager.AddToRoleAsync(adminUser, adminRole.Name);
                }
            }
        }
    }
}
