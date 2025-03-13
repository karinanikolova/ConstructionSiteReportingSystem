using ConstructionSiteReportingSystem.Core.Models.Suggest;
using ConstructionSiteReportingSystem.Core.Services;
using ConstructionSiteReportingSystem.Core.Services.Contracts;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities.Contracts;

namespace ConstructionSiteReportingSystem.Tests.UnitTests
{
	[TestFixture]
	public class WorkTypeServiceTests : UnitTestsBase
	{
		private IWorkTypeService _workTypeService;
		private IRepository _testRepository;

		[OneTimeSetUp]
		public void Setup()
		{
			_testRepository = new Repository(_dbContext);
			_workTypeService = new WorkTypeService(_testRepository);

		}

		[Test]
		public async Task GetWorkTypesForReviewAsync_ShouldReturnAllWorkTypesForReview()
		{
			var workTypes = TestWorkTypes.Where(wt => !wt.IsApproved).ToArray();
			var workTypesResult = await _workTypeService.GetWorkTypesForReviewAsync();

			var workTypesCount = workTypes.Count();
			var workTypesResultCount = workTypesResult.Count();

			Assert.Multiple(() =>
			{
				Assert.That(workTypesResult, Is.Not.Null, "The tested service returned a null result for work types for review.");
				Assert.That(workTypesCount, Is.EqualTo(workTypesResultCount), "The evaluated collections count are not equal.");
			});

			int i = default;

			foreach (var workTypeResult in workTypesResult.OrderBy(wt => wt.Id))
			{
				Assert.Multiple(() =>
				{
					Assert.That(workTypeResult.Id, Is.EqualTo(workTypes[i].Id), "The evaluated work type ids are not equal.");
					Assert.That(workTypeResult.Name, Is.EqualTo(workTypes[i++].Name), "The evaluated work type names are not the same.");
				});
			}
		}

		[Test]
		public async Task ApproveWorkTypeAsync_ShouldApproveSuccessfully_WithValidWorkTypeId()
		{
			var workType = TestWorkTypes.First(wt => !wt.IsApproved);

			await _workTypeService.ApproveWorkTypeAsync(workType.Id);

			Assert.That(workType.IsApproved, Is.True);
		}

		[Test]
		public async Task AreThereCWorkTypesToApproveAsync_ShouldReturnTrue()
		{
			var areThereWorkTypesToApprove = await _workTypeService.AreThereWorkTypesToApproveAsync();

			Assert.That(areThereWorkTypesToApprove, Is.True);
		}

		[Test]
		public async Task DoesUnapprovedWorkTypeExistAsync_ShoulReturnTrue_WithValidWorkTypeId()
		{
			var unapprovedWorkTypeId = TestWorkTypes.Last(wt => !wt.IsApproved).Id;

			var doesUnapprovedWorkTypeExist = await _workTypeService.DoesUnapprovedWorkTypeExistAsync(unapprovedWorkTypeId);

			Assert.That(doesUnapprovedWorkTypeExist, Is.True);
		}

		[Test]
		public async Task EditWorkTypeAsync_ShoulEditSuccessfully_WithValidMethodArguments()
		{
			var workTypeId = TestWorkTypes.Skip(1).Take(1).First().Id;
			var workTypeAddFormModel = new WorkTypeAddFormModel()
			{
				Name = "Edited Work Type Name"
			};

			await _workTypeService.EditWorkTypeAsync(workTypeId, workTypeAddFormModel);
			var workTypeAfterEdit = await _workTypeService.GetWorkTypeAddFormModelByIdAsync(workTypeId);

			Assert.That(workTypeAfterEdit!.Name, Is.EqualTo(workTypeAddFormModel.Name));
		}

		[Test]
		public async Task RemoveWorkTypeAsync_ShouldRemoveSuccessfully_WithValidWorkTypeId()
		{
			var workTypeIdToRemove = TestWorkTypes.First(wt => !wt.IsApproved).Id;
			var workTypesCountBeforeRemoving = TestWorkTypes.Where(wt => !wt.IsApproved).Count();

			await _workTypeService.RemoveWorkTypeAsync(workTypeIdToRemove);

			var workTypesAfterRemoving = await _workTypeService.GetWorkTypesForReviewAsync();

			Assert.Multiple(() =>
			{
				Assert.That(workTypesAfterRemoving.Count(), Is.EqualTo(workTypesCountBeforeRemoving - 1), "The work type has not been removed from the database.");
				Assert.That(workTypesAfterRemoving.FirstOrDefault(wt => wt.Id == workTypeIdToRemove), Is.Null, "There is a work type found with the removed id.");
			});
		}
	}
}
