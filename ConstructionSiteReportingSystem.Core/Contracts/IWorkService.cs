using ConstructionSiteReportingSystem.Core.Models.Work;
using Task = System.Threading.Tasks.Task;

namespace ConstructionSiteReportingSystem.Core.Contracts
{
	public interface IWorkService
	{
		Task<IEnumerable<SiteServiceModel>> GetAllSitesAsync();

		Task<IEnumerable<WorkTypeServiceModel>> GetAllWorkTypesAsync();

		Task<IEnumerable<StageServiceModel>> GetAllStagesAsync();

		Task<IEnumerable<ContractorServiceModel>> GetAllContractorsAsync();

		Task<IEnumerable<UnitServiceModel>> GetAllUnitsAsync();

		Task<WorkEditFormModel?> GetWorkEditFormModelByIdAsync(int workId);

		Task<WorkServiceModel?> GetWorkServiceModelByIdAsync(int workId);

		Task<bool> DoesSiteExistAsync(int siteId);

		Task<bool> DoesWorkTypeExistAsync(int workTypeId);

		Task<bool> DoesStageExistAsync(int stageId);

		Task<bool> DoesContractorExistAsync(int contractorId);

		Task<bool> DoesUnitExistAsync(int unitId);

		Task<bool> DoesWorkExistAsync(int workId);

		Task<int> CreateWorkAsync(WorkAddFormModel workModel, DateTime carryOutDate, string userId);

		Task EditWorkAsync(int workId, WorkEditFormModel workModel, DateTime carryOutDate);

		Task DeleteWorkAsync(int workId);
	}
}
