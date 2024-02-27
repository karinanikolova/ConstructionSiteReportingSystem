using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ConstructionSiteReportingSystem.Infrastructure.Data
{
    public class ConstructionSiteDbContext : IdentityDbContext
    {
        public ConstructionSiteDbContext(DbContextOptions<ConstructionSiteDbContext> options)
            : base(options)
        {
        }
    }
}
