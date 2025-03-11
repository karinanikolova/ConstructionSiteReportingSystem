using ConstructionSiteReportingSystem.Core.Models.Suggest;
using ConstructionSiteReportingSystem.Core.Services;
using ConstructionSiteReportingSystem.Core.Services.Contracts;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities.Contracts;

namespace ConstructionSiteReportingSystem.Tests.UnitTests
{
	[TestFixture]
	public class UnitServiceTests : UnitTestsBase
	{
		private IUnitService _unitService;
		private IRepository _testRepository;

		[OneTimeSetUp]
		public void Setup()
		{
			_testRepository = new Repository(_dbContext);
			_unitService = new UnitService(_testRepository);
		}

		[Test]
		public async Task GetUnitsForReviewAsync_ShouldReturnUnitsForReview()
		{
			var units = TestUnits.Where(u => !u.IsApproved).ToArray();

			var unitsResult = await _unitService.GetUnitsForReviewAsync();

			Assert.That(unitsResult, Is.Not.Null, "The tested service returned a null result.");
			Assert.That(unitsResult.Count(), Is.EqualTo(units.Length), "The evaluated unit counts are not equal.");

			int i = default;

			foreach (var unitResult in unitsResult.OrderBy(s => s.Id))
			{
				Assert.Multiple(() =>
				{
					Assert.That(unitResult.Id, Is.EqualTo(units[i].Id), "The evaluated unit ids are not equal.");
					Assert.That(unitResult.Type, Is.EqualTo(units[i++].Type), "The evaluated unit types are not the same.");
				});
			}
		}

		[Test]
		public async Task GetUnitAddFormModelByIdAsync_ShouldReturnCorrectModel_WithValidUnitId()
		{
			var unit = TestUnits.Last();
			var unitId = unit.Id;
			var unitType = unit.Type;

			var unitResult = await _unitService.GetUnitAddFormModelByIdAsync(unitId);

			Assert.That(unitResult, Is.Not.Null, "The tested service returned a null result.");
			Assert.That(unitResult!.Type, Is.EqualTo(unitType), "The evaluated unit types are not the same.");
		}

		[Test]
		public async Task ApproveUnitAsync_ShouldApprove_WithValidUnitId()
		{
			var unit = TestUnits.First(s => !s.IsApproved);

			await _unitService.ApproveUnitAsync(unit.Id);
			var isApprovedAfterChange = unit.IsApproved;

			Assert.That(isApprovedAfterChange, Is.True);
		}

		[Test]
		public async Task AreThereUnitsToApproveAsync_ShouldReturnTrue()
		{
			var areThereUnitsToApprove = await _unitService.AreThereUnitsToApproveAsync();

			Assert.That(areThereUnitsToApprove, Is.True);
		}

		[Test]
		public async Task DoesUnapprovedUnitExistAsync_ShouldReturnTrue_WithValidUnitId()
		{
			var unapprovedUnitId = TestUnits.First(u => !u.IsApproved).Id;

			var doesUnapprovedUnitExist = await _unitService.DoesUnapprovedUnitExistAsync(unapprovedUnitId);

			Assert.That(doesUnapprovedUnitExist, Is.True);
		}

		[Test]
		public async Task EditUnitAsync_ShouldEditSuccessfully_WithValidMethodArguments()
		{
			var unitId = TestUnits.First().Id;
			var unitAddFormModel = new UnitAddFormModel()
			{
				Type = "piece/m"
			};

			await _unitService.EditUnitAsync(unitId, unitAddFormModel);
			var unitAfterEdit = await _unitService.GetUnitAddFormModelByIdAsync(unitId);

			Assert.That(unitAfterEdit!.Type, Is.EqualTo(unitAddFormModel.Type));
		}

		[Test]
		public async Task RemoveUnitAsync_ShouldRemoveSuccessfully_WithValidUnitId()
		{
			var unitIdToRemove = TestUnits.First(c => !c.IsApproved).Id;
			var unitsCountBeforeRemoving = TestUnits.Where(c => !c.IsApproved).Count();

			await _unitService.RemoveUnitAsync(unitIdToRemove);

			var unitsAfterRemoving = await _unitService.GetUnitsForReviewAsync();

			Assert.Multiple(() =>
			{
				Assert.That(unitsAfterRemoving.Count(), Is.EqualTo(unitsCountBeforeRemoving - 1), "The unit has not been removed from the database.");
				Assert.That(unitsAfterRemoving.FirstOrDefault(c => c.Id == unitIdToRemove), Is.Null, "There is a unit found with the removed id.");
			});
		}
	}
}
