using ConstructionSiteReportingSystem.Core.Models.Home;

namespace ConstructionSiteReportingSystem.Core.Contracts
{
	public interface IHomeService
	{
		Task<IEnumerable<IndexViewModel>> SitesForPreviewAsync();
	}
}
