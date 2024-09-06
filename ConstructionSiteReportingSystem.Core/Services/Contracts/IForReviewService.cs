using ConstructionSiteReportingSystem.Core.Models.Admin.Index;
using ConstructionSiteReportingSystem.Core.Models.Suggest;
using ConstructionSiteReportingSystem.Core.Models.Work;

namespace ConstructionSiteReportingSystem.Core.Services.Contracts
{
	public interface IForReviewService
    {
        Task<ForReviewViewModel> GetForReviewViewModelAsync();

        Task<ContractorAddFormModel?> GetContractorAddFormModelByIdAsync(int contractorId);

		Task<IEnumerable<ContractorServiceModel>> GetContractorsForReviewAsync();

		Task<IEnumerable<StageServiceModel>> GetStagesForReviewAsync();

		Task<IEnumerable<UnitServiceModel>> GetUnitsForReviewAsync();

		Task<IEnumerable<WorkTypeServiceModel>> GetWorkTypesForReviewAsync();

		Task ApproveContractorAsync(int contractorId);

		Task EditContractorAsync(int contractorId, ContractorAddFormModel contractorModel);

		Task RemoveContractorAsync(int contractorId);

		Task<bool> DoesUnapprovedContractorExistAsync(int contractorId);

		Task<bool> AreThereContractorsToApproveAsync();
	}
}