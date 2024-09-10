using ConstructionSiteReportingSystem.Core.Models.Suggest;
using ConstructionSiteReportingSystem.Core.Models.Work;

namespace ConstructionSiteReportingSystem.Core.Services.Contracts
{
	public interface IUnitService
	{
		Task<UnitAddFormModel?> GetUnitAddFormModelByIdAsync(int unitId);

		Task<IEnumerable<UnitServiceModel>> GetUnitsForReviewAsync();

		Task ApproveUnitAsync(int unitId);

		Task EditUnitAsync(int unitId, UnitAddFormModel unitModel);

		Task RemoveUnitAsync(int unitId);

		Task<bool> DoesUnapprovedUnitExistAsync(int unitId);

		Task<bool> AreThereUnitsToApproveAsync();
	}
}