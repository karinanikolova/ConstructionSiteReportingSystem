using ConstructionSiteReportingSystem.Core.Models.Suggest;
using ConstructionSiteReportingSystem.Core.Services.Contracts;
using ConstructionSiteReportingSystem.Infrastructure.Data.Models;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities.Contracts;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

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
				IsApproved = isUserAdmin
			};

			await _repository.AddAsync<Contractor>(contractor);
			await _repository.SaveChangesAsync();
		}

		public async Task CreateStageAsync(StageAddFormModel stageModel, bool isUserAdmin)
		{
			var stage = new Stage()
			{
				Name = stageModel.Name,
				IsApproved = isUserAdmin
			};

			await _repository.AddAsync<Stage>(stage);
			await _repository.SaveChangesAsync();
		}

		public async Task CreateUnitAsync(UnitAddFormModel unitModel, bool isUserAdmin)
		{
			var unit = new Unit()
			{
				Type = unitModel.Type,
				IsApproved = isUserAdmin
			};

			await _repository.AddAsync<Unit>(unit);
			await _repository.SaveChangesAsync();
		}

		public async Task CreateWorkTypeAsync(WorkTypeAddFormModel workTypeModel, bool isUserAdmin)
		{
			var workType = new WorkType()
			{
				Name = workTypeModel.Name,
				IsApproved = isUserAdmin
			};

			await _repository.AddAsync<WorkType>(workType);
			await _repository.SaveChangesAsync();
		}

		public async Task<bool> DoesContractorNameExistAsync(string contractorName)
		{
			return await _repository.AllReadOnly<Contractor>()
				.AnyAsync(c => c.Name == contractorName);
		}

		public async Task<bool> DoesStageNameExistAsync(string stageName)
		{
			return await _repository.AllReadOnly<Stage>()
				.AnyAsync(s => s.Name == stageName);
		}

		public async Task<bool> DoesUnitTypeExistAsync(string unitType)
		{
			return await _repository.AllReadOnly<Unit>()
				.AnyAsync(u => u.Type == unitType);
		}

		public async Task<bool> DoesWorkTypeNameExistAsync(string workTypeName)
		{
			return await _repository.AllReadOnly<WorkType>()
				.AnyAsync(wt => wt.Name == workTypeName);
		}
	}
}