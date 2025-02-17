using ConstructionSiteReportingSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ConstructionSiteReportingSystem.Tests.Mocks
{
	/// <summary>
	/// Static class for database mock which provides Instance property for creating an in-memory database with a unique name without any seeded data.
	/// </summary>
	public static class DatabaseMock
	{
		public static ConstructionSiteDbContext Instance
		{
			get
			{
				var options = new DbContextOptionsBuilder<ConstructionSiteDbContext>()
					.UseInMemoryDatabase("ConstructionSiteInMemoryDb" + DateTime.Now.Ticks.ToString())
					.Options;

				return new ConstructionSiteDbContext(options, false);
			}
		}
	}
}