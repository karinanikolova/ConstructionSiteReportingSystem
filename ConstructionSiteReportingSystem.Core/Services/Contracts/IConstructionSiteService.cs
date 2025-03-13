using ConstructionSiteReportingSystem.Core.Models.Admin.Site;
using ConstructionSiteReportingSystem.Core.Models.Site;
using ConstructionSiteReportingSystem.Infrastructure.Enums;

namespace ConstructionSiteReportingSystem.Core.Services.Contracts
{
	public interface IConstructionSiteService
    {
        Task<SiteQueryServiceModel?> GetSiteAsync(int siteId, string? stage = null, string? searchDate = null, DateSorting dateSorting = DateSorting.Newest, int currentPage = 1, int worksPerPage = 1);

        Task<IEnumerable<SiteInfoViewModel>> GetAllSiteInfoViewModelsAsync();

        Task<IEnumerable<string>> GetAllStagesNamesAsync();

		Task<string> GetSiteInformationAsync(int siteId);

		Task<bool> DoesSiteNameExistAsync(string siteName);

		Task<bool> DoesSiteExistAsync(int siteId);

		Task CreateSiteAsync(SiteFormModel siteModel, DateTime finishDate);

		Task EditSiteAsync(int siteId, SiteFormModel siteModel, DateTime finishDate);

		Task<SiteViewModel?> GetSiteViewModelByIdAsync(int siteId);

		Task<SiteFormModel?> GetSiteFormModelByIdAsync(int siteId);

		Task DeleteSiteAsync(int siteId);

		Task<IEnumerable<int>?> GetSiteWorkIdsAsync(int siteId);
	}
}