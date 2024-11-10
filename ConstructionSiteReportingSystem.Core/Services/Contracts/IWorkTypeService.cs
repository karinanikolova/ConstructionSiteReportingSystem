using ConstructionSiteReportingSystem.Core.Models.Suggest;
using ConstructionSiteReportingSystem.Core.Models.Work;

namespace ConstructionSiteReportingSystem.Core.Services.Contracts
{
	public interface IWorkTypeService
    {
		Task<WorkTypeAddFormModel?> GetWorkTypeAddFormModelByIdAsync(int workTypeId);

		Task<IEnumerable<WorkTypeServiceModel>> GetWorkTypesForReviewAsync();

		Task ApproveWorkTypeAsync(int workTypeId);

		Task EditWorkTypeAsync(int workTypeId, WorkTypeAddFormModel workTypeModel);

		Task RemoveWorkTypeAsync(int workTypeId);

		Task<bool> DoesUnapprovedWorkTypeExistAsync(int workTypeId);

		Task<bool> AreThereWorkTypesToApproveAsync();
	}
}