using ConstructionSiteReportingSystem.Core.Contracts;
using ConstructionSiteReportingSystem.Core.Models.Work;
using ConstructionSiteReportingSystem.Infrastructure.Data.Models;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities.Contracts;
using Microsoft.EntityFrameworkCore;
using DateTimeConverter = ConstructionSiteReportingSystem.Core.Common.DateTimeConverter;
using Task = System.Threading.Tasks.Task;

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
				.AnyAsync(wt => wt.Id == workTypeId);
		}

		public async Task<bool> DoesStageExistAsync(int stageId)
		{
			return await _repository.AllReadOnly<Stage>()
				.AnyAsync(s => s.Id == stageId);
		}

		public async Task<bool> DoesContractorExistAsync(int contractorId)
		{
			return await _repository.AllReadOnly<Contractor>()
				.AnyAsync(c => c.Id == contractorId);
		}

		public async Task<bool> DoesUnitExistAsync(int unitId)
		{
			return await _repository.AllReadOnly<Unit>()
				.AnyAsync(u => u.Id == unitId);
		}

		public async Task<bool> DoesWorkExistAsync(int workId)
		{
			return await _repository.AllReadOnly<Work>()
				.AnyAsync(w => w.Id == workId);
		}

		public async Task<WorkEditFormModel?> GetWorkEditFormModelByIdAsync(int workId)
		{
			var work = await _repository.AllReadOnly<Work>() // Should use _repository.GetByIdAsync<Work>(workId) method.
				.Where(w => w.Id == workId)
				.Select(w => new WorkEditFormModel()
				{
					WorkTypeId = w.WorkTypeId,
					SiteId = w.SiteId,
					Description = w.Description,
					CarryOutDate = DateTimeConverter.ConvertDateToString(w.CarryOutDate),
					StageId = w.StageId,
					ContractorId = w.ContractorId,
					Quantity = w.Quantity,
					UnitId = w.UnitId,
					CostPerUnit = w.CostPerUnit,
					TotalCost = w.TotalCost,
					CreatorId = w.CreatorId
				})
				.FirstOrDefaultAsync();

			if (work != null)
			{
				work.Sites = await GetAllSitesAsync();
				work.WorkTypes = await GetAllWorkTypesAsync();
				work.Stages = await GetAllStagesAsync();
				work.Contractors = await GetAllContractorsAsync();
				work.Units = await GetAllUnitsAsync();
			}

			return work;
		}

		public async Task<WorkServiceModel?> GetWorkServiceModelByIdAsync(int workId) =>
			await _repository.AllReadOnly<Work>()
			.Where(w => w.Id == workId)
			.Select(w => new WorkServiceModel()
			{
				Id = w.Id,
				WorkType = w.WorkType.Name,
				Description = w.Description,
				CarryOutDate = DateTimeConverter.ConvertDateToString(w.CarryOutDate),
				SiteId = w.SiteId,
				Stage = w.Stage.Name,
				Contractor = w.Contractor.Name,
				Quantity = w.Quantity,
				Unit = w.Unit.Type,
				CostPerUnit = w.CostPerUnit,
				TotalCost = w.TotalCost,
				CreatorId = w.CreatorId
			})
			.FirstOrDefaultAsync();

		public async Task<int> CreateWorkAsync(WorkAddFormModel workModel, DateTime carryOutDate, string userId)
		{
			var work = new Work()
			{
				WorkTypeId = workModel.WorkTypeId,
				SiteId = workModel.SiteId,
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

			return workModel.SiteId;
		}

		public async Task EditWorkAsync(int workId, WorkEditFormModel workModel,  DateTime carryOutDate)
		{
			var work = await _repository.GetByIdAsync<Work>(workId);

			if (work != null)
			{
				work.SiteId = workModel.SiteId;
				work.WorkTypeId = workModel.WorkTypeId;
				work.Description = workModel.Description;
				work.CarryOutDate = carryOutDate;
				work.StageId = workModel.StageId;
				work.ContractorId = workModel.ContractorId;
				work.Quantity = workModel.Quantity;
				work.UnitId = workModel.UnitId;
				work.CostPerUnit = workModel.CostPerUnit;
				work.TotalCost = CalculateTotalCost(workModel.Quantity, workModel.CostPerUnit);
			}

			await _repository.SaveChangesAsync();
		}

		public async Task DeleteWorkAsync(int workId)
		{
			var workToDelete = await _repository.GetByIdAsync<Work>(workId);

			if (workToDelete != null)
			{
				_repository.Delete<Work>(workToDelete);
				await _repository.SaveChangesAsync();
			}
		}

		private decimal CalculateTotalCost(double quantity, decimal costPerUnit)
		{
			return (decimal)quantity * costPerUnit;
		}
	}
}
