using ConstructionSiteReportingSystem.Core.Models.Suggest;
using ConstructionSiteReportingSystem.Core.Models.Work;
using ConstructionSiteReportingSystem.Core.Services.Contracts;
using ConstructionSiteReportingSystem.Infrastructure.Data.Models;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities.Contracts;
using Task = System.Threading.Tasks.Task;
using Microsoft.EntityFrameworkCore;

namespace ConstructionSiteReportingSystem.Core.Services
{
	public class StageService : IStageService
	{
		private readonly IRepository _repository;

		public StageService(IRepository repository)
		{
			_repository = repository;
		}

		public async Task<IEnumerable<StageServiceModel>> GetStagesForReviewAsync()
		{
			return await _repository.AllReadOnly<Stage>()
				.Where(s => s.IsApproved == false)
				.Select(s => new StageServiceModel()
				{
					Id = s.Id,
					Name = s.Name
				})
			.ToListAsync();
		}

		public async Task ApproveStageAsync(int stageId)
		{
			var stageToApprove = await _repository.GetByIdAsync<Stage>(stageId);

			if (stageToApprove != null && stageToApprove.IsApproved == false)
			{
				stageToApprove.IsApproved = true;

				await _repository.SaveChangesAsync();
			}
		}

		public async Task<bool> AreThereStagesToApproveAsync()
		{
			return await _repository.AllReadOnly<Stage>()
				.Where(s => s.IsApproved == false)
				.AnyAsync();
		}

		public async Task<bool> DoesUnapprovedStageExistAsync(int stageId)
		{
			return await _repository.AllReadOnly<Stage>()
				.Where(s => s.IsApproved == false)
				.AnyAsync(s => s.Id == stageId);
		}

		public async Task EditStageAsync(int stageId, StageAddFormModel stageModel)
		{
			var stage = await _repository.GetByIdAsync<Stage>(stageId);

			if (stage != null)
			{
				stage.Name = stageModel.Name.Trim();
			}

			await _repository.SaveChangesAsync();
		}

		public async Task<StageAddFormModel?> GetStageAddFormModelByIdAsync(int stageId)
		{
			return await _repository.AllReadOnly<Stage>()
				.Where(s => s.Id == stageId)
				.Select(s => new StageAddFormModel()
				{
					Name = s.Name
				})
				.FirstOrDefaultAsync();
		}

		public async Task RemoveStageAsync(int stageId)
		{
			var stageToRemove = await _repository.GetByIdAsync<Stage>(stageId);

			if (stageToRemove != null && stageToRemove.IsApproved == false)
			{
				_repository.Delete<Stage>(stageToRemove);
				await _repository.SaveChangesAsync();
			}
		}
	}
}