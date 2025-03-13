using ConstructionSiteReportingSystem.Core.Models.Suggest;
using ConstructionSiteReportingSystem.Core.Models.Work;
using ConstructionSiteReportingSystem.Core.Services.Contracts;
using ConstructionSiteReportingSystem.Infrastructure.Data.Models;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities.Contracts;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace ConstructionSiteReportingSystem.Core.Services
{
	public class WorkTypeService : IWorkTypeService
	{
		private readonly IRepository _repository;

		public WorkTypeService(IRepository repository)
		{
			_repository = repository;
		}

		public async Task<IEnumerable<WorkTypeServiceModel>> GetWorkTypesForReviewAsync()
		{
			return await _repository.AllReadOnly<WorkType>()
				.Where(wt => wt.IsApproved == false)
				.Select(wt => new WorkTypeServiceModel()
				{
					Id = wt.Id,
					Name = wt.Name
				})
				.ToListAsync();
		}

		public async Task ApproveWorkTypeAsync(int workTypeId)
		{
			var workTypeToApprove = await _repository.GetByIdAsync<WorkType>(workTypeId);

			if (workTypeToApprove != null && workTypeToApprove.IsApproved == false)
			{
				workTypeToApprove.IsApproved = true;

				await _repository.SaveChangesAsync();
			}
		}

		public async Task<bool> AreThereWorkTypesToApproveAsync()
		{
			return await _repository.AllReadOnly<WorkType>()
				.AnyAsync(wt => !wt.IsApproved);
		}

		public async Task<bool> DoesUnapprovedWorkTypeExistAsync(int workTypeId)
		{
			return await _repository.AllReadOnly<WorkType>()
				.AnyAsync(wt => wt.Id == workTypeId && !wt.IsApproved);
		}

		public async Task EditWorkTypeAsync(int workTypeId, WorkTypeAddFormModel workTypeModel)
		{
			var workType = await _repository.GetByIdAsync<WorkType>(workTypeId);

			if (workType != null)
			{
				workType.Name = workTypeModel.Name;
				await _repository.SaveChangesAsync();
			}
		}

		public async Task<WorkTypeAddFormModel?> GetWorkTypeAddFormModelByIdAsync(int workTypeId)
		{
			return await _repository.AllReadOnly<WorkType>()
				.Where(wt => wt.Id == workTypeId)
				.Select(wt => new WorkTypeAddFormModel()
				{
					Name = wt.Name
				})
				.FirstOrDefaultAsync();
		}

		public async Task RemoveWorkTypeAsync(int workTypeId)
		{
			var workTypeToRemove = await _repository.GetByIdAsync<WorkType>(workTypeId);

			if (workTypeToRemove != null && workTypeToRemove.IsApproved == false)
			{
				_repository.Delete<WorkType>(workTypeToRemove);
				await _repository.SaveChangesAsync();
			}
		}
	}
}