using ConstructionSiteReportingSystem.Core.Contracts;
using ConstructionSiteReportingSystem.Core.Models.Work;
using ConstructionSiteReportingSystem.Infrastructure.Data.Models;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities.Contracts;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace ConstructionSiteReportingSystem.Core.Services
{
	public class WorkService : IWorkService
	{
		private readonly IRepository _repository;

		public WorkService(IRepository repository)
		{
			_repository = repository;
		}

		public async Task<IEnumerable<SiteServiceModel>> GetAllSitesAsync()
		{
			return await _repository.AllReadOnly<Site>()
				.Select(s => new SiteServiceModel()
				{
					Id = s.Id,
					Name = s.Name
				})
				.ToListAsync();
		}

		public async Task<IEnumerable<ContractorServiceModel>> GetAllContractorsAsync()
		{
			return await _repository.AllReadOnly<Contractor>()
				.Select(c => new ContractorServiceModel()
				{ 
					Id = c.Id,
					Name = c.Name 
				})
				.ToListAsync();
		}

		public async Task<IEnumerable<StageServiceModel>> GetAllStagesAsync()
		{
			return await _repository.AllReadOnly<Stage>()
				.Select(s => new StageServiceModel()
				{
					Id = s.Id,
					Name = s.Name
				})
				.ToListAsync();
		}

		public async Task<IEnumerable<UnitServiceModel>> GetAllUnitsAsync()
		{
			return await _repository.AllReadOnly<Unit>()
				.Select(u => new UnitServiceModel()
				{
					Id = u.Id,
					Type = u.Type
				})
				.ToListAsync();
		}

		public async Task<IEnumerable<WorkTypeServiceModel>> GetAllWorkTypesAsync()
		{
			return await _repository.AllReadOnly<WorkType>()
				.Select(wt => new WorkTypeServiceModel()
				{
					Id = wt.Id,
					Name = wt.Name
				})
				.ToListAsync();
		}

		public async Task<bool> DoesSiteExistAsync(int siteId)
		{
			return await _repository.AllReadOnly<Site>()
				.AnyAsync(s => s.Id == siteId);
		}

		public async Task<bool> DoesWorkTypeExistAsync(int workTypeId)
		{
			return await _repository.AllReadOnly<WorkType>()
				.AnyAsync(s => s.Id == workTypeId);
		}

		public async Task<bool> DoesStageExistAsync(int stageId)
		{
			return await _repository.AllReadOnly<Stage>()
				.AnyAsync(s => s.Id == stageId);
		}

		public async Task<bool> DoesContractorExistAsync(int contractorId)
		{
			return await _repository.AllReadOnly<Contractor>()
				.AnyAsync(s => s.Id == contractorId);
		}

		public async Task<bool> DoesUnitExistAsync(int unitId)
		{
			return await _repository.AllReadOnly<Unit>()
				.AnyAsync(s => s.Id == unitId);
		}

		public async Task<int> CreateWorkAsync(WorkFormModel workModel, DateTime carryOutDate, string userId)
		{
			var work = new Work()
			{
				WorkTypeId = workModel.WorkTypeId,
				Description = workModel.Description,
				CarryOutDate = carryOutDate,
				StageId = workModel.StageId,
				ContractorId = workModel.ContractorId,
				Quantity = workModel.Quantity,
				UnitId = workModel.UnitId,
				CostPerUnit = workModel.CostPerUnit,
				TotalCost = CalculateTotalCost(workModel.Quantity, workModel.CostPerUnit),
				CreatorId = userId
			};

			await _repository.AddAsync<Work>(work);
			await _repository.SaveChangesAsync();

			var siteWork = new SiteWork()
			{
				SiteId = workModel.SiteId,
				WorkId = work.Id
			};

			await _repository.AddAsync<SiteWork>(siteWork);
			await _repository.SaveChangesAsync();

			return workModel.SiteId;
		}

		private decimal CalculateTotalCost(double quantity, decimal costPerUnit)
		{
			return (decimal)quantity * costPerUnit;
		}
	}
}
