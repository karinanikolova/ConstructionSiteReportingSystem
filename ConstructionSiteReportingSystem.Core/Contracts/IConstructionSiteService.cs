using ConstructionSiteReportingSystem.Core.Models.Site;

namespace ConstructionSiteReportingSystem.Core.Contracts
{
	public interface IConstructionSiteService
	{
		Task<SiteViewModel> GetSiteAsync(int projectSiteNameId);
	}
}
