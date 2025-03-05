using ConstructionSiteReportingSystem.Core.Models.Suggest;
using ConstructionSiteReportingSystem.Core.Services;
using ConstructionSiteReportingSystem.Core.Services.Contracts;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities.Contracts;

namespace ConstructionSiteReportingSystem.Tests.UnitTests
{
	[TestFixture]
	public class SuggestServiceTests : UnitTestsBase
	{
		private ISuggestService _suggestService;
		private IContractorService _contractorService;
		private IStageService _stageService;
		private IUnitService _unitService;
		private IWorkTypeService _workTypeService;
		private IRepository _testRepository;

		[OneTimeSetUp]
		public void Setup()
		{
			_testRepository = new Repository(_dbContext);
			_suggestService = new SuggestService(_testRepository);
			_contractorService = new ContractorService(_testRepository);
			_stageService = new StageService(_testRepository);
			_unitService = new UnitService(_testRepository);
			_workTypeService = new WorkTypeService(_testRepository);
		}

		[Test]
		public async Task CreateContractorAsync_ShouldCreateSuccessfully_WithValidMethodArguments()
		{
			var contractorsUnapprovedCountBeforeCreation = TestContractors.Count(c => !c.IsApproved);
			var contractorAddFormModel = new ContractorAddFormModel()
			{
				Name = "New Contractor Name"
			};

			await _suggestService.CreateContractorAsync(contractorAddFormModel, false);

			var unapprovedContractorsAfterCreation = await _contractorService.GetContractorsForReviewAsync();
			var contractorsUnapprovedCountAfterCreation = unapprovedContractorsAfterCreation.Count();

			Assert.That(contractorsUnapprovedCountAfterCreation, Is.EqualTo(contractorsUnapprovedCountBeforeCreation + 1), "No new contractor has been added to the database.");

			var newlyCreatedContractor = unapprovedContractorsAfterCreation.FirstOrDefault(s => s.Name == contractorAddFormModel.Name);

			Assert.Multiple(() =>
			{
				Assert.That(newlyCreatedContractor, Is.Not.Null, "The task of creating a new contractor was not successful and the returned value is null.");
				Assert.That(newlyCreatedContractor.Name, Is.EqualTo(contractorAddFormModel.Name), "The evaluated contractor names are not the same.");
			});
			Assert.That(newlyCreatedContractor.Id, Is.Not.Zero, "The evaluated contractor id is equal to zero.");
		}

		[Test]
		public async Task CreateStageAsync_ShouldCreateSuccessfully_WithValidMethodArguments()
		{
			var stagesUnapprovedCountBeforeCreation = TestStages.Count(c => !c.IsApproved);
			var stageAddFormModel = new StageAddFormModel()
			{
				Name = "New Stage Name"
			};

			await _suggestService.CreateStageAsync(stageAddFormModel, false);

			var unapprovedStagesAfterCreation = await _stageService.GetStagesForReviewAsync();
			var stagesUnapprovedCountAfterCreation = unapprovedStagesAfterCreation.Count();

			Assert.That(stagesUnapprovedCountAfterCreation, Is.EqualTo(stagesUnapprovedCountBeforeCreation + 1), "No new stage has been added to the database.");

			var newlyCreatedStage = unapprovedStagesAfterCreation.FirstOrDefault(s => s.Name == stageAddFormModel.Name);

			Assert.Multiple(() =>
			{
				Assert.That(newlyCreatedStage, Is.Not.Null, "The task of creating a new stage was not successful and the returned value is null.");
				Assert.That(newlyCreatedStage.Name, Is.EqualTo(stageAddFormModel.Name), "The evaluated stage names are not the same.");
			});
			Assert.That(newlyCreatedStage.Id, Is.Not.Zero, "The evaluated stage id is equal to zero.");
		}

		[Test]
		public async Task CreateUnitAsync_ShouldCreateSuccessfully_WithValidMethodArguments()
		{
			var unitsUnapprovedCountBeforeCreation = TestUnits.Count(c => !c.IsApproved);
			var unitAddFormModel = new UnitAddFormModel()
			{
				Type = "piece"
			};

			await _suggestService.CreateUnitAsync(unitAddFormModel, false);

			var unapprovedUnitsAfterCreation = await _unitService.GetUnitsForReviewAsync();
			var unitsUnapprovedCountAfterCreation = unapprovedUnitsAfterCreation.Count();

			Assert.That(unitsUnapprovedCountAfterCreation, Is.EqualTo(unitsUnapprovedCountBeforeCreation + 1), "No new unit has been added to the database.");

			var newlyCreatedUnit = unapprovedUnitsAfterCreation.FirstOrDefault(s => s.Type == unitAddFormModel.Type);

			Assert.Multiple(() =>
			{
				Assert.That(newlyCreatedUnit, Is.Not.Null, "The task of creating a new unit was not successful and the returned value is null.");
				Assert.That(newlyCreatedUnit.Type, Is.EqualTo(unitAddFormModel.Type), "The evaluated unit types are not the same.");
			});
			Assert.That(newlyCreatedUnit.Id, Is.Not.Zero, "The evaluated unit id is equal to zero.");
		}

		[Test]
		public async Task CreateWorkTypeAsync_ShouldCreateSuccessfully_WithValidMethodArguments()
		{
			var workTypesUnapprovedCountBeforeCreation = TestWorkTypes.Count(c => !c.IsApproved);
			var workTypeAddFormModel = new WorkTypeAddFormModel()
			{
				Name = "New Work Type Name"
			};

			await _suggestService.CreateWorkTypeAsync(workTypeAddFormModel, false);

			var unapprovedWorkTypesAfterCreation = await _workTypeService.GetWorkTypesForReviewAsync();
			var workTypesUnapprovedCountAfterCreation = unapprovedWorkTypesAfterCreation.Count();

			Assert.That(workTypesUnapprovedCountAfterCreation, Is.EqualTo(workTypesUnapprovedCountBeforeCreation + 1), "No new work type has been added to the database.");

			var newlyCreatedWorkType = unapprovedWorkTypesAfterCreation.FirstOrDefault(s => s.Name == workTypeAddFormModel.Name);

			Assert.Multiple(() =>
			{
				Assert.That(newlyCreatedWorkType, Is.Not.Null, "The task of creating a new work type was not successful and the returned value is null.");
				Assert.That(newlyCreatedWorkType.Name, Is.EqualTo(workTypeAddFormModel.Name), "The evaluated work type names are not the same.");
			});
			Assert.That(newlyCreatedWorkType.Id, Is.Not.Zero, "The evaluated work type id is equal to zero.");
		}

		[Test]
		public async Task DoesContractorNameExistAsync_ShouldReturnTrue_WithValidContractorName()
		{
			var validContractorName = TestContractors.First().Name;
			var result = await _suggestService.DoesContractorNameExistAsync(validContractorName);

			Assert.That(result, Is.True);
		}

		[Test]
		public async Task DoesStageNameExistAsync_ShouldReturnTrue_WithValidStageName()
		{
			var validStageName = TestStages.First().Name;
			var result = await _suggestService.DoesStageNameExistAsync(validStageName);

			Assert.That(result, Is.True);
		}

		[Test]
		public async Task DoesUnitTypeExistAsync_ShouldReturnTrue_WithValidUnitType()
		{
			var validUnitType = TestUnits.First().Type;
			var result = await _suggestService.DoesUnitTypeExistAsync(validUnitType);

			Assert.That(result, Is.True);
		}

		[Test]
		public async Task DoesWorkTypeNameExistAsync_ShouldReturnTrue_WithValidWorkTypeName()
		{
			var validWorkTypeName = TestWorkTypes.First().Name;
			var result = await _suggestService.DoesWorkTypeNameExistAsync(validWorkTypeName);

			Assert.That(result, Is.True);
		}
	}
}