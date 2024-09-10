using ConstructionSiteReportingSystem.Core.Models.Suggest;
using ConstructionSiteReportingSystem.Core.Models.Work;

namespace ConstructionSiteReportingSystem.Core.Services.Contracts
{
	public interface IStageService
	{
		Task<StageAddFormModel?> GetStageAddFormModelByIdAsync(int stageId);

		Task<IEnumerable<StageServiceModel>> GetStagesForReviewAsync();

		Task ApproveStageAsync(int stageId);

		Task EditStageAsync(int stageId, StageAddFormModel stageModel);

		Task RemoveStageAsync(int stageId);

		Task<bool> DoesUnapprovedStageExistAsync(int stageId);

		Task<bool> AreThereStagesToApproveAsync();
	}
}