using ConstructionSiteReportingSystem.ModelBinders;
using Microsoft.AspNetCore.Mvc;

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

                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });

            await app.RunAsync();
        }
    }
}