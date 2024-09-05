using ConstructionSiteReportingSystem.Core.Models.Suggest;
using ConstructionSiteReportingSystem.Core.Services.Contracts;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities.Contracts;
using Contractor = ConstructionSiteReportingSystem.Infrastructure.Data.Models.Contractor;

namespace ConstructionSiteReportingSystem.Core.Services
{
	public class SuggestService : ISuggestService
	{
		private readonly IRepository _repository;

        public SuggestService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateContractorAsync(ContractorAddFormModel contractorModel, bool isUserAdmin)
		{
			var contractor = new Contractor()
			{
				Name = contractorModel.Name,
				IsApproved = isUserAdmin ? true : false
			};

			await _repository.AddAsync<Contractor>(contractor);
			await _repository.SaveChangesAsync();
		}
	}
}