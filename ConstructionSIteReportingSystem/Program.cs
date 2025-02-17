using ConstructionSiteReportingSystem.Infrastructure.Data;
using ConstructionSiteReportingSystem.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConstructionSiteReportingSystem
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddApplicationDbContext(builder.Configuration);
            builder.Services.AddApplicationIdentity(builder.Configuration);

            builder.Services.AddControllersWithViews(options =>
            {
                options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
                options.ModelBinderProviders.Insert(1, new DoubleModelBinderProvider());
                options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
            });

            builder.Services.AddApplicationServices();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error/500");
                app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "ConstructionSite Site",
                    pattern: "/ConstructionSite/Site/{id}/{information}",
                    defaults: new { Controller = "ConstructionSite", Action = "Site" }
                );

                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });

			// Applying database migrations before starting the application
			using (var scope = app.Services.CreateScope())
			{
				var services = scope.ServiceProvider;

				try
				{
					var dbContext = services.GetRequiredService<ConstructionSiteDbContext>();

					if (dbContext.Database.IsRelational())
					{
						await dbContext.Database.MigrateAsync();
					}
				}
				catch (Exception ex)
				{
					var logger = services.GetRequiredService<ILogger<Program>>();
					logger.LogError(ex, "An error occurred while applying database migrations.");
				}
			}
			// Creating admin role after migrations are applied
			await app.CreateAdminRoleAsync();

			//Starting the application
			await app.RunAsync();
        }
    }
}