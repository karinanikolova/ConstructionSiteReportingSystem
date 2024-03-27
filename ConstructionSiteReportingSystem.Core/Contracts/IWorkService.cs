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
	}
}
