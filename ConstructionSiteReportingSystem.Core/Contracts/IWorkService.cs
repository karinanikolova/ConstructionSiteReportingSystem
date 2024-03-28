using ConstructionSiteReportingSystem.Core.Models.Work;

namespace ConstructionSiteReportingSystem.Core.Contracts
{
	public interface IWorkService
	{
		Task<IEnumerable<SiteServiceModel>> GetAllSitesAsync();

		Task<IEnumerable<WorkTypeServiceModel>> GetAllWorkTypesAsync();

		Task<IEnumerable<StageServiceModel>> GetAllStagesAsync();

		Task<IEnumerable<ContractorServiceModel>> GetAllContractorsAsync();

		Task<IEnumerable<UnitServiceModel>> GetAllUnitsAsync();

		Task<bool> DoesSiteExistAsync(int siteId);

		Task<bool> DoesWorkTypeExistAsync(int workTypeId);

		Task<bool> DoesStageExistAsync(int stageId);

		Task<bool> DoesContractorExistAsync(int contractorId);

		Task<bool> DoesUnitExistAsync(int unitId);

		Task<int> CreateWorkAsync(WorkFormModel workModel, DateTime carryOutDate, string userId);
	}
}
