using ConstructionSiteReportingSystem.Core.Models.Home;

namespace ConstructionSiteReportingSystem.Core.Services.Contracts
{
    public interface IHomeService
    {
        Task<IEnumerable<IndexViewModel>> SitesForPreviewAsync();
    }
}
