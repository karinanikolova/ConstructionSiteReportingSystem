using ConstructionSiteReportingSystem.Core.Common;
using ConstructionSiteReportingSystem.Core.Models.Work;
using ConstructionSiteReportingSystem.Core.Services;
using ConstructionSiteReportingSystem.Core.Services.Contracts;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities.Contracts;
using ConstructionSiteReportingSystem.Infrastructure.Enums;
using System.Globalization;
using static ConstructionSiteReportingSystem.Core.Constants.ValidationConstants;
using static ConstructionSiteReportingSystem.Infrastructure.Enums.DateSorting;

namespace ConstructionSiteReportingSystem.Tests.UnitTests
{
	[TestFixture]
	public class WorkServiceTests : UnitTestsBase
	{
		private IWorkService _workService;
		private IConstructionSiteService _constructionSiteService;
		private IRepository _testRepository;

		[OneTimeSetUp]
		public void Setup()
		{
			_testRepository = new Repository(_dbContext);
			_workService = new WorkService(_testRepository);
			_constructionSiteService = new ConstructionSiteService(_testRepository);
		}

		[Test]
		public async Task GetAllSiteServiceModelsAsync_ShouldReturnAllServiceModels()
		{
			var sites = TestSites;

			var sitesResult = await _workService.GetAllSiteServiceModelsAsync();

			Assert.That(sitesResult, Is.Not.Null, "The tested service returned a null result.");
			Assert.That(sitesResult.Count(), Is.EqualTo(sites.Count()), "The evaluated site counts are not equal.");

			foreach (var site in sites)
			{
				var siteResult = sitesResult.First(s => s.Id == site.Id);

				Assert.That(siteResult.Name, Is.EqualTo(site.Name), "The evaluated site names are not the same.");
			}
		}

		[Test]
		public async Task GetAllContractorsAsync_ShouldReturnAllContractors()
		{
			var contractors = TestContractors.Where(c => c.IsApproved);

			var contractorsResult = await _workService.GetAllContractorsAsync();

			Assert.That(contractorsResult, Is.Not.Null, "The tested service returned a null result.");
			Assert.That(contractorsResult.Count(), Is.EqualTo(contractors.Count()), "The evaluated contractor counts are not equal.");

			foreach (var contractor in contractors)
			{
				var contractorResult = contractorsResult.First(c => c.Id == contractor.Id);

				Assert.That(contractorResult.Name, Is.EqualTo(contractor.Name), "The evaluated contractor names are not the same.");
			}
		}

		[Test]
		public async Task GetAllStagesAsync_ShouldReturnAllStages()
		{
			var stages = TestStages.Where(s => s.IsApproved);

			var stagesResult = await _workService.GetAllStagesAsync();

			Assert.That(stagesResult, Is.Not.Null, "The tested service returned a null result.");
			Assert.That(stagesResult.Count(), Is.EqualTo(stages.Count()), "The evaluated stage counts are not equal.");

			foreach (var stage in stages)
			{
				var stageResult = stagesResult.First(s => s.Id == stage.Id);

				Assert.That(stageResult.Name, Is.EqualTo(stage.Name), "The evaluated stage names are not the same.");
			}
		}

		[Test]
		public async Task GetAllUnitsAsync_ShouldReturnAllUnits()
		{
			var units = TestUnits.Where(u => u.IsApproved);

			var unitsResult = await _workService.GetAllUnitsAsync();

			Assert.That(unitsResult, Is.Not.Null, "The tested service returned a null result.");
			Assert.That(unitsResult.Count(), Is.EqualTo(units.Count()), "The evaluated unit counts are not equal.");

			foreach (var unit in units)
			{
				var unitResult = unitsResult.First(u => u.Id == unit.Id);

				Assert.That(unitResult.Type, Is.EqualTo(unit.Type), "The evaluated unit types are not the same.");
			}
		}

		[Test]
		public async Task GetAllWorkTypesAsync_ShouldReturnAllWorkTypes()
		{
			var workTypes = TestWorkTypes.Where(wt => wt.IsApproved);

			var workTypesResult = await _workService.GetAllWorkTypesAsync();

			Assert.That(workTypesResult, Is.Not.Null, "The tested service returned a null result.");
			Assert.That(workTypesResult.Count(), Is.EqualTo(workTypes.Count()), "The evaluated work type counts are not equal.");

			foreach (var workType in workTypes)
			{
				var workTypeResult = workTypesResult.First(wt => wt.Id == workType.Id);

				Assert.That(workTypeResult.Name, Is.EqualTo(workType.Name), "The evaluated work type names are not the same.");
			}
		}

		[Test]
		public async Task DoesWorkTypeExistAsync_ShouldReturnTrue_WithValidWorkTypeId()
		{
			var workTypeId = TestWorkTypes.First(wt => wt.IsApproved).Id;
			var result = await _workService.DoesWorkTypeExistAsync(workTypeId);

			Assert.That(result, Is.True);
		}

		[Test]
		public async Task DoesStageExistAsync_ShouldReturnTrue_WithValidStageId()
		{
			var stageId = TestStages.First(s => s.IsApproved).Id;
			var result = await _workService.DoesStageExistAsync(stageId);

			Assert.That(result, Is.True);
		}

		[Test]
		public async Task DoesContractorExistAsync_ShouldReturnTrue_WithValidContractorId()
		{
			var contractorId = TestContractors.First(c => c.IsApproved).Id;
			var result = await _workService.DoesContractorExistAsync(contractorId);

			Assert.That(result, Is.True);
		}

		[Test]
		public async Task DoesUnitExistAsync_ShouldReturnTrue_WithValidUnitId()
		{
			var unitId = TestUnits.First(u => u.IsApproved).Id;
			var result = await _workService.DoesUnitExistAsync(unitId);

			Assert.That(result, Is.True);
		}

		[Test]
		public async Task DoesWorkExistAsync_ShouldReturnTrue_WithValidWorkId()
		{
			var workId = TestWorks.First().Id;
			var result = await _workService.DoesWorkExistAsync(workId);

			Assert.That(result, Is.True);
		}

		[Test]
		public async Task GetWorkEditFormModelByIdAsync_ShouldReturnCorrectEditFormModel_WithValidWorkId()
		{
			var work = TestWorks.Last();

			var workModelResult = await _workService.GetWorkEditFormModelByIdAsync(work.Id);

			Assert.That(workModelResult, Is.Not.Null, "The tested service returned a null result.");

			Assert.Multiple(() =>
			{
				Assert.That(workModelResult.SiteId, Is.EqualTo(work.SiteId), "The evaluated work site ids are not equal.");
				Assert.That(workModelResult.WorkTypeId, Is.EqualTo(work.WorkTypeId), "The evaluated work type ids are not equal.");
				Assert.That(workModelResult.Description, Is.EqualTo(work.Description), "The evaluated work descriptions are not the same.");
				Assert.That(workModelResult.CarryOutDate, Is.EqualTo(DateTimeConverter.ConvertDateToString(work.CarryOutDate)), "The evaluated work carry out dates are not the same.");
				Assert.That(workModelResult.StageId, Is.EqualTo(work.StageId), "The evaluated work stage ids are not equal.");
				Assert.That(workModelResult.ContractorId, Is.EqualTo(work.ContractorId), "The evaluated work contractor ids are not equal.");
				Assert.That(workModelResult.Quantity, Is.EqualTo(work.Quantity), "The evaluated work quantities are not equal.");
				Assert.That(workModelResult.UnitId, Is.EqualTo(work.UnitId), "The evaluated measurement unit ids are not equal.");
				Assert.That(workModelResult.CostPerUnit, Is.EqualTo(work.CostPerUnit), "The evaluated work costs per measurement unit are not equal.");
				Assert.That(workModelResult.TotalCost, Is.EqualTo(work.TotalCost), "The evaluated work total costs are not equal.");
				Assert.That(workModelResult.CreatorId, Is.EqualTo(work.CreatorId), "The evaluated work creator ids are not the same.");
			});
		}

		[Test]
		public async Task GetWorkServiceModelByIdAsync_ShouldReturnCorrectServiceModel_WithValidWorkId()
		{
			var work = TestWorks.First();

			var workModelResult = await _workService.GetWorkServiceModelByIdAsync(work.Id);

			Assert.That(workModelResult, Is.Not.Null, "The tested service returned a null result.");

			Assert.Multiple(() =>
			{
				Assert.That(workModelResult.WorkType, Is.EqualTo(work.WorkType.Name), "The evaluated work type names are not the same.");
				Assert.That(workModelResult.Description, Is.EqualTo(work.Description), "The evaluated work descriptions are not the same.");
				Assert.That(workModelResult.CarryOutDate, Is.EqualTo(DateTimeConverter.ConvertDateToString(work.CarryOutDate)), "The evaluated work carry out dates are not the same.");
				Assert.That(workModelResult.SiteId, Is.EqualTo(work.SiteId), "The evaluated work site ids are not equal.");
				Assert.That(workModelResult.Stage, Is.EqualTo(work.Stage.Name), "The evaluated work stage names are not the same.");
				Assert.That(workModelResult.Contractor, Is.EqualTo(work.Contractor.Name), "The evaluated work contractor names are not the same.");
				Assert.That(workModelResult.Quantity, Is.EqualTo(work.Quantity), "The evaluated work quantities are not equal.");
				Assert.That(workModelResult.Unit, Is.EqualTo(work.Unit.Type), "The evaluated measurement unit types are not the same.");
				Assert.That(workModelResult.CostPerUnit, Is.EqualTo(work.CostPerUnit), "The evaluated work costs per measurement unit are not equal.");
				Assert.That(workModelResult.TotalCost, Is.EqualTo(work.TotalCost), "The evaluated work total costs are not equal.");
				Assert.That(workModelResult.CreatorId, Is.EqualTo(work.CreatorId), "The evaluated work creator ids are not the same.");
			});
		}

		[Test]
		public async Task CreateWorkAsync_ShouldCreateSuccessfully()
		{
			var site = TestSites.First(s => s.Id == 3);
			var userId = TestUsers.First().Id;
			var worksIdsInDbBeforeCreating = TestWorks.Where(w => w.SiteId == site.Id).Select(w => w.Id);
			var worksCountInDbBeforeCreating = worksIdsInDbBeforeCreating.Count();

			var newWork = new WorkAddFormModel()
			{
				WorkTypeId = 1,
				SiteId = site.Id,
				Description = "New work description.",
				CarryOutDate = "09/07/2025",
				StageId = 2,
				ContractorId = 1,
				Quantity = 100,
				UnitId = 4,
				CostPerUnit = 15.35M,
				TotalCost = (decimal)100 * 15.35M
			};

			var date = DateTime.ParseExact(newWork.CarryOutDate, DateTimePreferredFormat, CultureInfo.InvariantCulture);

			await _workService.CreateWorkAsync(newWork, date, userId);

			var siteResult = await _constructionSiteService.GetSiteAsync(site.Id, null, null, Newest, 1, worksCountInDbBeforeCreating + 1);
			var worksCountInDbAfterCreating = siteResult.Works.Count();

			Assert.That(worksCountInDbAfterCreating, Is.EqualTo(worksCountInDbBeforeCreating + 1), "No new work has been added to the database.");

			int newlyCreatedWorkId = default;

			foreach (var work in siteResult.Works)
			{
				if (worksIdsInDbBeforeCreating.Any(id => id != work.Id))
				{
					newlyCreatedWorkId = work.Id;
				}
			}

			var newlyCreatedWork = siteResult.Works.FirstOrDefault(w => w.Id == newlyCreatedWorkId);

			if (newlyCreatedWork != null)
			{
				Assert.Multiple(() =>
				{
					Assert.That(newlyCreatedWork.WorkName, Is.EqualTo(TestWorkTypes.First(wt => wt.Id == newWork.WorkTypeId).Name), "The evaluated work type names are not the same.");
					Assert.That(newlyCreatedWork.Description, Is.EqualTo(newWork.Description), "The evaluated work descriptions are not the same.");
					Assert.That(DateTimeConverter.ConvertDateToString(newlyCreatedWork.CarryOutDate), Is.EqualTo(newWork.CarryOutDate), "The evaluated work carry out dates are not the same.");
					Assert.That(newlyCreatedWork.Stage, Is.EqualTo(TestStages.First(s => s.Id == newWork.StageId).Name), "The evaluated work stage names are not the same.");
					Assert.That(newlyCreatedWork.Contractor, Is.EqualTo(TestContractors.First(c => c.Id == newWork.ContractorId).Name), "The evaluated work contractors are not the same.");
					Assert.That(newlyCreatedWork.CostPerUnit, Is.EqualTo(newWork.CostPerUnit), "The evaluated work costs per unit are not equal.");
					Assert.That(newlyCreatedWork.Unit, Is.EqualTo(TestUnits.First(u => u.Id == newWork.UnitId).Type), "The evaluated work measurement unit types are not the same.");
					Assert.That(newlyCreatedWork.TotalCost, Is.EqualTo(newWork.TotalCost), "The evaluated work total costs are not equal.");
					Assert.That(newlyCreatedWork.Creator, Is.EqualTo(TestUsers.First(u => u.Id == userId).UserName), "The evaluated work creator user names are not equal.");
				});
			}
		}

		[Test]
		public async Task EditWorkAsync_ShoulEditSuccessfully_WithValidMethodArguments()
		{
			var workId = TestWorks.First().Id;

			var workEditFormModel = new WorkEditFormModel()
			{
				SiteId = 3,
				WorkTypeId = 2,
				Description = "New work description.",
				CarryOutDate = "17/02/2025",
				StageId = 2,
				ContractorId = 3,
				Quantity = 57,
				UnitId = 2,
				CostPerUnit = 35.5M,
				TotalCost = 2023.5M
			};

			await _workService.EditWorkAsync(workId, workEditFormModel, DateTime.ParseExact(workEditFormModel.CarryOutDate, DateTimePreferredFormat, CultureInfo.InvariantCulture, DateTimeStyles.None));
			var workAfterEdit = await _workService.GetWorkEditFormModelByIdAsync(workId);

			Assert.Multiple(() =>
			{
				Assert.That(workAfterEdit!.SiteId, Is.EqualTo(workEditFormModel.SiteId), "The evaluated site ids are not equal.");
				Assert.That(workAfterEdit!.WorkTypeId, Is.EqualTo(workEditFormModel.WorkTypeId), "The evaluated work type ids are not equal.");
				Assert.That(workAfterEdit!.Description, Is.EqualTo(workEditFormModel.Description), "The evaluated work descriptions are not the same.");
				Assert.That(workAfterEdit!.CarryOutDate, Is.EqualTo(workEditFormModel.CarryOutDate), "The evaluated work carry out dates are not the same.");
				Assert.That(workAfterEdit!.StageId, Is.EqualTo(workEditFormModel.StageId), "The evaluated work stage ids are not equal.");
				Assert.That(workAfterEdit!.ContractorId, Is.EqualTo(workEditFormModel.ContractorId), "The evaluated contractor ids are not equal.");
				Assert.That(workAfterEdit!.Quantity, Is.EqualTo(workEditFormModel.Quantity), "The evaluated work quantities are not equal.");
				Assert.That(workAfterEdit!.UnitId, Is.EqualTo(workEditFormModel.UnitId), "The evaluated work measurement unit ids are not equal.");
				Assert.That(workAfterEdit!.CostPerUnit, Is.EqualTo(workEditFormModel.CostPerUnit), "The evaluated work costs per unit are not equal.");
				Assert.That(workAfterEdit!.TotalCost, Is.EqualTo(workEditFormModel.TotalCost), "The evaluated work total costs are not equal.");
			});
		}

		[Test]
		public async Task DeleteWorkAsync_ShoulDeleteSuccessfully_WithValidWorkId()
		{
			var workToDelete = TestWorks.Skip(2).Take(1).First();
			var siteIdOfDeletedWork = workToDelete.SiteId;
			var worksBeforeDeleting = TestWorks.Count(w => w.SiteId == siteIdOfDeletedWork);

			await _workService.DeleteWorkAsync(workToDelete.Id);

			var siteOfDeletedWork = await _constructionSiteService.GetSiteAsync(siteIdOfDeletedWork, null, null, DateSorting.Newest, 1, worksBeforeDeleting - 1);
			var worksAfterDeleting = siteOfDeletedWork.Works.Count();

			Assert.Multiple(() =>
			{
				Assert.That(worksAfterDeleting, Is.EqualTo(worksBeforeDeleting - 1), "The work has not been removed from the database.");
				Assert.That(siteOfDeletedWork.Works.FirstOrDefault(w => w.Id == workToDelete.Id), Is.Null, "Work with a supposedly deleted id has been found.");
			});
		}
	}
}