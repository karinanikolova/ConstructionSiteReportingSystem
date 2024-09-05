using ConstructionSiteReportingSystem.Core.Models.Suggest;

namespace ConstructionSiteReportingSystem.Core.Services.Contracts
{
	public interface ISuggestService
    {
        Task CreateContractorAsync(ContractorAddFormModel contractorModel, bool isUserAdmin);
    }
}