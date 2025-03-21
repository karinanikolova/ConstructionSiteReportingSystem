﻿using ConstructionSiteReportingSystem.Core.Models.Suggest;
using ConstructionSiteReportingSystem.Core.Models.Work;

namespace ConstructionSiteReportingSystem.Core.Services.Contracts
{
	public interface IContractorService
    {
        Task<ContractorAddFormModel?> GetContractorAddFormModelByIdAsync(int contractorId);

		Task<IEnumerable<ContractorServiceModel>> GetContractorsForReviewAsync();

		Task ApproveContractorAsync(int contractorId);

		Task EditContractorAsync(int contractorId, ContractorAddFormModel contractorModel);

		Task RemoveContractorAsync(int contractorId);

		Task<bool> DoesUnapprovedContractorExistAsync(int contractorId);

		Task<bool> AreThereContractorsToApproveAsync();
	}
}