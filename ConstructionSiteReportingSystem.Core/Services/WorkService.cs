using ConstructionSiteReportingSystem.Core.Contracts;
using ConstructionSiteReportingSystem.Core.Models.Work;
using ConstructionSiteReportingSystem.Infrastructure.Data.Models;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities.Contracts;
using Microsoft.EntityFrameworkCore;

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
	}
}
