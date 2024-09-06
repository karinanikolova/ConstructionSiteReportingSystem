using ConstructionSiteReportingSystem.Core.Models.Admin.Index;
using ConstructionSiteReportingSystem.Core.Models.Suggest;
using ConstructionSiteReportingSystem.Core.Models.Work;
using ConstructionSiteReportingSystem.Core.Services.Contracts;
using ConstructionSiteReportingSystem.Infrastructure.Data.Models;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities.Contracts;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace ConstructionSiteReportingSystem.Core.Services
{
	public class ForReviewService : IForReviewService
	{
		private readonly IRepository _repository;

		public ForReviewService(IRepository repository)
		{
			_repository = repository;
		}

		public async Task<ForReviewViewModel> GetForReviewViewModelAsync()
		{
			var forReviewViewModel = new ForReviewViewModel();

			forReviewViewModel.AreThereContractorsForReview = await _repository.AllReadOnly<Contractor>()
				.Where(c => c.IsApproved == false)
				.AnyAsync();

			forReviewViewModel.AreThereStagesForReview = await _repository.AllReadOnly<Stage>()
				.Where(s => s.IsApproved == false)
				.AnyAsync();

			forReviewViewModel.AreThereUnitsForReview = await _repository.AllReadOnly<Unit>()
				.Where(u => u.IsApproved == false)
				.AnyAsync();

			forReviewViewModel.AreThereWorkTypesForReview = await _repository.AllReadOnly<WorkType>()
				.Where(wt => wt.IsApproved == false)
				.AnyAsync();

			return forReviewViewModel;
		}

		public async Task<IEnumerable<ContractorServiceModel>> GetContractorsForReviewAsync()
		{
			return await _repository.AllReadOnly<Contractor>()
				.Where(c => c.IsApproved == false)
				.Select(c => new ContractorServiceModel()
				{
					Id = c.Id,
					Name = c.Name
				})
				.ToListAsync();
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

		public async Task<IEnumerable<UnitServiceModel>> GetUnitsForReviewAsync()
		{
			return await _repository.AllReadOnly<Unit>()
				.Where(u => u.IsApproved == false)
				.Select(u => new UnitServiceModel()
				{
					Id = u.Id,
					Type = u.Type
				})
				.ToListAsync();
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

		public async Task ApproveContractorAsync(int contractorId)
		{
			var contractorToApprove = await _repository.GetByIdAsync<Contractor>(contractorId);

			if (contractorToApprove != null && contractorToApprove.IsApproved == false)
			{
				contractorToApprove.IsApproved = true;

				await _repository.SaveChangesAsync();
			}
		}

		public async Task<bool> AreThereContractorsToApproveAsync()
		{
			return await _repository.AllReadOnly<Contractor>()
				.Where(c => c.IsApproved == false)
				.AnyAsync();
		}

		public async Task RemoveContractorAsync(int contractorId)
		{
			var contractorToRemove = await _repository.GetByIdAsync<Contractor>(contractorId);

			if (contractorToRemove != null && contractorToRemove.IsApproved == false)
			{
				_repository.Delete<Contractor>(contractorToRemove);
				await _repository.SaveChangesAsync();
			}
		}

		public async Task<ContractorAddFormModel?> GetContractorAddFormModelByIdAsync(int contractorId)
		{
			return await _repository.AllReadOnly<Contractor>()
				.Where(c => c.Id == contractorId)
				.Select(c => new ContractorAddFormModel()
				{
					Name = c.Name
				})
				.FirstOrDefaultAsync();
		}

		public async Task EditContractorAsync(int contractorId, ContractorAddFormModel contractorModel)
		{
			var contractor = await _repository.GetByIdAsync<Contractor>(contractorId);

			if (contractor != null)
			{
				contractor.Name = contractorModel.Name;
			}

			await _repository.SaveChangesAsync();
		}

		public async Task<bool> DoesUnapprovedContractorExistAsync(int contractorId)
		{
			return await _repository.AllReadOnly<Contractor>()
				.Where(c => c.IsApproved == false)
				.AnyAsync(c => c.Id == contractorId);
		}
	}
}