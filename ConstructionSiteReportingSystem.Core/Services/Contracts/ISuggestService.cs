using ConstructionSiteReportingSystem.Core.Models.Suggest;

namespace ConstructionSiteReportingSystem.Core.Services.Contracts
{
	public interface ISuggestService
    {
        Task CreateContractorAsync(ContractorAddFormModel contractorModel, bool isUserAdmin);

        Task CreateStageAsync(StageAddFormModel stageModel, bool isUserAdmin);

        Task CreateUnitAsync(UnitAddFormModel unitModel, bool isUserAdmin);

        Task CreateWorkTypeAsync(WorkTypeAddFormModel workTypeModel, bool isUserAdmin);
	}
}