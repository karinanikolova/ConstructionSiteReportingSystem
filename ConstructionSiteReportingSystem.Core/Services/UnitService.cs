using ConstructionSiteReportingSystem.Core.Models.Suggest;
using ConstructionSiteReportingSystem.Core.Models.Work;
using ConstructionSiteReportingSystem.Core.Services.Contracts;
using ConstructionSiteReportingSystem.Infrastructure.Data.Models;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities.Contracts;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace ConstructionSiteReportingSystem.Core.Services
{
	public class UnitService : IUnitService
	{
		private readonly IRepository _repository;

		public UnitService(IRepository repository)
		{
			_repository = repository;
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

		public async Task<UnitAddFormModel?> GetUnitAddFormModelByIdAsync(int unitId)
		{
			return await _repository.AllReadOnly<Unit>()
				.Where(u => u.Id == unitId)
				.Select(u => new UnitAddFormModel()
				{
					Type = u.Type
				})
				.FirstOrDefaultAsync();
		}

		public async Task ApproveUnitAsync(int unitId)
		{
			var unitToApprove = await _repository.GetByIdAsync<Unit>(unitId);

			if (unitToApprove != null && unitToApprove.IsApproved == false)
			{
				unitToApprove.IsApproved = true;

				await _repository.SaveChangesAsync();
			}
		}

		public async Task<bool> AreThereUnitsToApproveAsync()
		{
			return await _repository.AllReadOnly<Unit>()
				.AnyAsync(u => !u.IsApproved);
		}

		public async Task<bool> DoesUnapprovedUnitExistAsync(int unitId)
		{
			return await _repository.AllReadOnly<Unit>()
				.AnyAsync(u => u.Id == unitId && !u.IsApproved);
		}

		public async Task EditUnitAsync(int unitId, UnitAddFormModel unitModel)
		{
			var unit = await _repository.GetByIdAsync<Unit>(unitId);

			if (unit != null)
			{
				unit.Type = unitModel.Type;
			}

			await _repository.SaveChangesAsync();
		}

		public async Task RemoveUnitAsync(int unitId)
		{
			var unitToRemove = await _repository.GetByIdAsync<Unit>(unitId);

			if (unitToRemove != null && unitToRemove.IsApproved == false)
			{
				_repository.Delete<Unit>(unitToRemove);
				await _repository.SaveChangesAsync();
			}
		}
	}
}