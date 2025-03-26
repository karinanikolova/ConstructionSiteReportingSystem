using ConstructionSiteReportingSystem.Core.Models.Work;
using Task = System.Threading.Tasks.Task;

namespace ConstructionSiteReportingSystem.Core.Services.Contracts
{
    public interface IWorkService
    {
		Task<SiteServiceModel?> GetSiteServiceModelByIdAsync(int siteId);

		Task<List<SiteServiceModel>> GetAllSiteServiceModelsAsync();

        Task<IEnumerable<WorkTypeServiceModel>> GetAllWorkTypesAsync();

        Task<IEnumerable<StageServiceModel>> GetAllStagesAsync();

        Task<IEnumerable<ContractorServiceModel>> GetAllContractorsAsync();

        Task<IEnumerable<UnitServiceModel>> GetAllUnitsAsync();

        Task<WorkEditFormModel?> GetWorkEditFormModelByIdAsync(int workId);

        Task<WorkServiceModel?> GetWorkServiceModelByIdAsync(int workId);

        Task<bool> DoesWorkTypeExistAsync(int workTypeId);

        Task<bool> DoesStageExistAsync(int stageId);

        Task<bool> DoesContractorExistAsync(int contractorId);

        Task<bool> DoesUnitExistAsync(int unitId);

        Task<bool> DoesWorkExistAsync(int workId);

        Task CreateWorkAsync(WorkAddFormModel workModel, DateTime carryOutDate, string userId);

        Task EditWorkAsync(int workId, WorkEditFormModel workModel, DateTime carryOutDate);

        Task DeleteWorkAsync(int workId);
    }
}