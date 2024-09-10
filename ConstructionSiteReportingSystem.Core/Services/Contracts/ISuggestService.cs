using ConstructionSiteReportingSystem.Core.Models.Suggest;

namespace ConstructionSiteReportingSystem.Core.Services.Contracts
{
	public interface ISuggestService
    {
        Task CreateContractorAsync(ContractorAddFormModel contractorModel, bool isUserAdmin);

        Task<bool> DoesContractorNameExistAsync(string contractorName);

        Task CreateStageAsync(StageAddFormModel stageModel, bool isUserAdmin);

		Task<bool> DoesStageNameExistAsync(string stageName);

		Task CreateUnitAsync(UnitAddFormModel unitModel, bool isUserAdmin);

		Task<bool> DoesUnitTypeExistAsync(string unitType);

		Task CreateWorkTypeAsync(WorkTypeAddFormModel workTypeModel, bool isUserAdmin);

		Task<bool> DoesWorkTypeNameExistAsync(string workTypeName);
	}
}