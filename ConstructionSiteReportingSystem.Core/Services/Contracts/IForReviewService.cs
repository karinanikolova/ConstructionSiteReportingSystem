using ConstructionSiteReportingSystem.Core.Models.Admin.Index;
using ConstructionSiteReportingSystem.Core.Models.Work;

namespace ConstructionSiteReportingSystem.Core.Services.Contracts
{
	public interface IForReviewService
    {
        Task<ForReviewViewModel> GetForReviewViewModelAsync();

		Task<IEnumerable<ContractorServiceModel>> GetContractorsForReviewAsync();

		Task<IEnumerable<StageServiceModel>> GetStagesForReviewAsync();

		Task<IEnumerable<UnitServiceModel>> GetUnitsForReviewAsync();

		Task<IEnumerable<WorkTypeServiceModel>> GetWorkTypesForReviewAsync();
	}
}