using ConstructionSiteReportingSystem.Core.Models.Suggest;
using ConstructionSiteReportingSystem.Core.Services;
using ConstructionSiteReportingSystem.Core.Services.Contracts;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities.Contracts;

namespace ConstructionSiteReportingSystem.Tests.UnitTests
{
	[TestFixture]
	public class StageServiceTests : UnitTestsBase
	{
		private IStageService _stageService;
		private IRepository _testRepository;

		[OneTimeSetUp]
		public void Setup()
		{
			_testRepository = new Repository(_dbContext);
			_stageService = new StageService(_testRepository);
		}

		[Test]
		public async Task GetStagesForReviewAsync_ShouldReturnStagesForReview()
		{
			var stages = TestStages.Where(s => !s.IsApproved).ToArray();

			var stagesResult = await _stageService.GetStagesForReviewAsync();

			Assert.That(stagesResult, Is.Not.Null, "The tested service returned a null result.");
			Assert.That(stagesResult.Count(), Is.EqualTo(stages.Length), "The evaluated stage counts are not equal.");

			int i = default;

			foreach (var stageResult in stagesResult.OrderBy(s => s.Id))
			{
				Assert.Multiple(() =>
				{
					Assert.That(stageResult.Id, Is.EqualTo(stages[i].Id), "The evaluated stage ids are not equal.");
					Assert.That(stageResult.Name, Is.EqualTo(stages[i++].Name), "The evaluated stage names are not the same.");
				});
			}
		}

		[Test]
		public async Task ApproveStageAsync_ShouldApprove_WithValidStageId()
		{
			var stage = TestStages.First(s => !s.IsApproved);

			await _stageService.ApproveStageAsync(stage.Id);

			Assert.That(stage.IsApproved, Is.True);
		}

		[Test]
		public async Task AreThereStagesToApproveAsync_ShouldReturnTrue()
		{
			var areThereStagesToApprove = await _stageService.AreThereStagesToApproveAsync();

			Assert.That(areThereStagesToApprove, Is.True);
		}

		[Test]
		public async Task DoesUnapprovedStageExistAsync_ShouldReturnTrue_WithValidStageId()
		{
			var unapprovedStageId = TestStages.First(s => !s.IsApproved).Id;

			var doesUnapprovedStageExist = await _stageService.DoesUnapprovedStageExistAsync(unapprovedStageId);

			Assert.That(doesUnapprovedStageExist, Is.True);
		}

		[Test]
		public async Task EditStageAsync_ShouldEditSuccessfully_WithValidMethodArguments()
		{
			var stageId = TestStages.First().Id;
			var stageAddFormModel = new StageAddFormModel()
			{
				Name = "Edited Stage Name"
			};

			await _stageService.EditStageAsync(stageId, stageAddFormModel);
			var stageAfterEdit = await _stageService.GetStageAddFormModelByIdAsync(stageId);

			Assert.That(stageAfterEdit!.Name, Is.EqualTo(stageAddFormModel.Name));
		}

		[Test]
		public async Task GetStageAddFormModelByIdAsync_ShouldReturnCorrectModel_WithValidStageId()
		{
			var stage = TestStages.Last();
			var stageId = stage.Id;
			var stageName = stage.Name;

			var stageResult = await _stageService.GetStageAddFormModelByIdAsync(stageId);

			Assert.That(stageResult, Is.Not.Null, "The tested service returned a null result.");
			Assert.That(stageResult!.Name, Is.EqualTo(stageName), "The evaluated stage names are not the same.");
		}

		[Test]
		public async Task RemoveStageAsync_ShouldRemoveSuccessfully_WithValidStageId()
		{
			var stageIdToRemove = TestStages.First(s => !s.IsApproved).Id;
			var stagesCountBeforeRemoving = TestStages.Where(s => !s.IsApproved).Count();

			await _stageService.RemoveStageAsync(stageIdToRemove);

			var stagesAfterRemoving = await _stageService.GetStagesForReviewAsync();

			Assert.Multiple(() =>
			{
				Assert.That(stagesAfterRemoving.Count(), Is.EqualTo(stagesCountBeforeRemoving - 1), "The stage has not been removed from the database.");
				Assert.That(stagesAfterRemoving.FirstOrDefault(s => s.Id == stageIdToRemove), Is.Null, "There is a stage found with the removed id.");
			});
		}
	}
}