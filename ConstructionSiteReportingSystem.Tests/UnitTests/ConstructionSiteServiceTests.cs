using ConstructionSiteReportingSystem.Core.Common;
using ConstructionSiteReportingSystem.Core.Models.Admin.Site;
using ConstructionSiteReportingSystem.Core.Models.Site;
using ConstructionSiteReportingSystem.Core.Services;
using ConstructionSiteReportingSystem.Core.Services.Contracts;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities.Contracts;
using System.Globalization;
using static ConstructionSiteReportingSystem.Core.Constants.ValidationConstants;
using static ConstructionSiteReportingSystem.Infrastructure.Enums.DateSorting;

namespace ConstructionSiteReportingSystem.Tests.UnitTests
{
	[TestFixture]
	public class ConstructionSiteServiceTests : UnitTestsBase
	{
		private IConstructionSiteService _constructionSiteService;
		private IRepository _testRepository;

		[OneTimeSetUp]
		public void Setup()
		{
			_testRepository = new Repository(_dbContext);
			_constructionSiteService = new ConstructionSiteService(_testRepository);
		}

		[Test]
		public async Task DoesSiteExistAsync_ShouldReturnTrue_WithValidSiteId()
		{
			var firstSiteId = TestSites.First().Id;
			var result = await _constructionSiteService.DoesSiteExistAsync(firstSiteId);

			Assert.That(result, Is.True);
		}

		[Test]
		public async Task DoesSiteNameExistAsync_ShouldReturnTrue_WithValidSiteName()
		{
			var validSiteName = TestSites.First().Name;
			var result = await _constructionSiteService.DoesSiteNameExistAsync(validSiteName);

			Assert.That(result, Is.True);
		}

		[Test]
		public async Task GetSiteWorkIdsAsync_ShouldReturnCorrectIds_WithValidSiteId()
		{
			var siteId = TestSites.First().Id;
			var workIds = TestWorks
				.Where(w => w.SiteId == siteId)
				.Select(w => w.Id).
				ToList();

			var workIdsResult = await _constructionSiteService.GetSiteWorkIdsAsync(siteId);

			Assert.That(workIdsResult, Is.Not.Null, "The tested service returned a null result for work ids.");
			Assert.That(workIdsResult, Is.EqualTo(workIds), "The evaluated collections are not the same.");
		}

		[Test]
		public async Task GetSiteViewModelByIdAsync_ShouldReturnCorrectViewModel_WithValidSiteId()
		{
			var site = TestSites.First();
			var siteWorksCount = TestWorks.Where(w => w.SiteId == site.Id).Count();
			var siteWorkIds = TestWorks.Where(w => w.SiteId == site.Id).Select(w => w.Id);
			var siteUsersPostedCount = TestWorks
				.Where(w => w.SiteId == site.Id)
				.Select(w => w.CreatorId)
				.Distinct()
				.Count();

			var siteViewResult = await _constructionSiteService.GetSiteViewModelByIdAsync(site.Id);

			Assert.That(siteViewResult, Is.Not.Null, "The tested service returned a null result.");
			Assert.That(siteViewResult.Id, Is.EqualTo(site.Id), "The evaluated site ids are not equal.");
			Assert.That(siteViewResult.Name, Is.EqualTo(site.Name), "The evaluated site names are not the same.");
			Assert.That(siteViewResult.FinishDate, Is.EqualTo(site.FinishDate), "The evaluated site finish dates are not equal.");
			Assert.That(siteViewResult.WorksCount, Is.EqualTo(siteWorksCount), "The evaluated site works count are not equal.");
			Assert.That(siteViewResult.WorkIds, Is.EqualTo(siteWorkIds), "The evaluated site works ids are not equal.");
			Assert.That(siteViewResult.UsersPostedCount, Is.EqualTo(siteUsersPostedCount), "The evaluated users count that posted to the site are not equal.");
		}

		public async Task GetAllSitesAsync_ShouldReturnAllSites()
		{
			var sitesViewResult = await _constructionSiteService.GetAllSiteInfoViewModelsAsync();
			sitesViewResult = sitesViewResult.OrderBy(s => s.Id);

			Assert.That(sitesViewResult, Is.Not.Null, "The tested service returned a null result.");
			Assert.That(sitesViewResult.Select(s => s.Id), Is.EqualTo(TestSites.Select(s => s.Id)), "The evaluated sites ids are not equal.");
			Assert.That(sitesViewResult.Select(s => s.Name), Is.EqualTo(TestSites.Select(s => s.Name)), "The evaluated sites names are not the same.");
			Assert.That(sitesViewResult.Select(s => s.FinishDate), Is.EqualTo(TestSites.Select(s => DateTimeConverter.ConvertDateToString(s.FinishDate))), "The evaluated sites finish dates are not equal.");
			Assert.That(sitesViewResult.Count(), Is.EqualTo(TestSites.Count()), "The evaluated sites count are not equal.");
		}

		[Test]
		public async Task GetAllStagesNamesAsync_ShouldReturnCorrectNames()
		{
			var stagesNames = TestStages.Select(s => s.Name);

			var stagesNamesResult = await _constructionSiteService.GetAllStagesNamesAsync();
			stagesNamesResult = stagesNamesResult.Reverse();

			Assert.That(stagesNamesResult, Is.EqualTo(stagesNames), "The evaluated stages names are not the same.");
		}

		[Test]
		public async Task GetSiteInformationAsync_ShouldReturnCorrectinformation_WithValidSiteId()
		{
			var site = TestSites.First();
			var siteNameTransformed = site.Name.Replace(" ", "-");

			var siteInfoResult = await _constructionSiteService.GetSiteInformationAsync(site.Id);

			Assert.That(siteInfoResult, Is.Not.Null, "The tested service returned a null result.");
			Assert.That(siteInfoResult, Does.Contain(siteNameTransformed), "The evaluated site info string does not contain the site name.");
			Assert.That(siteInfoResult, Does.Not.Match(@"[ -\,.\/:-\@[-`{-~]"), "The evaluated site info string contains characters that are not supported.");
		}

		[Test]
		public async Task CreateSiteAsync_ShouldCreateSuccessfully()
		{
			var allSitesInDbBeforeCreating = TestSites.Count();

			var newSite = new SiteAddFormModel()
			{
				Name = "New Site Name",
				FinishDate = "05/07/2025",
				ImageUrl = "https://images.pexels.com/photos/220885/pexels-photo-220885.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
			};

			var date = DateTime.ParseExact(newSite.FinishDate, DateTimePreferredFormat, CultureInfo.InvariantCulture);

			await _constructionSiteService.CreateSiteAsync(newSite, date);

			var allSites = await _constructionSiteService.GetAllSiteInfoViewModelsAsync();
			var allSitesInDbAfterCreating = allSites.Count();
			Assert.That(allSitesInDbAfterCreating, Is.EqualTo(allSitesInDbBeforeCreating + 1), "No new site has been added to the database.");

			var newlyCreatedSite = allSites.FirstOrDefault(s => s.Name == newSite.Name);
			Assert.IsNotNull(newlyCreatedSite, "The task of creating a new site was not successful and the returned value is null.");
			Assert.That(newSite.FinishDate, Is.EqualTo(newlyCreatedSite.FinishDate), "The evaluated site finish dates are not equal.");
			Assert.NotZero(newlyCreatedSite.Id, "The evaluated site id is equal to zero.");
		}

		[Test]
		public async Task DeleteSiteAsync_ShouldDeleteSuccessfully()
		{
			var sitesInitially = await _constructionSiteService.GetAllSiteInfoViewModelsAsync();
			var siteToDelete = sitesInitially.First(s => s.Id == 3);
			var allSitesInDbBeforeDeleting = sitesInitially.Count();

			await _constructionSiteService.DeleteSiteAsync(siteToDelete.Id);

			var sitesAfter = await _constructionSiteService.GetAllSiteInfoViewModelsAsync();
			var allSitesInDbAfterDeleting = sitesAfter.Count();

			Assert.That(allSitesInDbAfterDeleting, Is.EqualTo(allSitesInDbBeforeDeleting - 1), "The site has not been removed from the database.");
			Assert.IsNull(sitesAfter.FirstOrDefault(s => s.Id == siteToDelete.Id));
		}

		[Test]
		public async Task GetSiteAsync_ShouldReturnCorrectSite_WithValidMethodArguments()
		{
			var site = TestSites.First(s => s.Id == 2);
			var date = DateTime.ParseExact("05/01/2025", DateTimePreferredFormat, CultureInfo.InvariantCulture);
			var siteWorksCount = TestWorks
				.Where(w => w.SiteId == site.Id && w.CarryOutDate == date)
				.Count();

			var siteQueryServiceResult = await _constructionSiteService.GetSiteAsync(site.Id, "Second Stage", "05/01/2025", Oldest);

			Assert.That(siteQueryServiceResult, Is.Not.Null, "The tested service returned a null result.");
			Assert.That(siteQueryServiceResult.SiteName, Is.EqualTo(site.Name), "The evaluated site names are not equal.");
			Assert.That(siteQueryServiceResult.ConstructionFinishDate, Is.EqualTo(site.FinishDate), "The evaluated site finish dates are not equal.");
			Assert.That(siteQueryServiceResult.TotalWorksCount, Is.EqualTo(siteWorksCount), "The evaluated site works count are not equal.");
		}

		[Test]
		public async Task GetSiteAsync_ShouldReturnCorrectSite_WithValidDefaultMethodArguments()
		{
			var site = TestSites.First(s => s.Id == 2);
			var siteWorks = TestWorks
				.Where(w => w.SiteId == site.Id);
			var siteWorksCount = siteWorks.Count();

			var siteQueryServiceResult = await _constructionSiteService.GetSiteAsync(site.Id, null, null, Newest);

			Assert.That(siteQueryServiceResult, Is.Not.Null, "The tested service returned a null result.");
			Assert.That(siteQueryServiceResult.SiteName, Is.EqualTo(site.Name), "The evaluated site names are not the same.");
			Assert.That(siteQueryServiceResult.ConstructionFinishDate, Is.EqualTo(site.FinishDate), "The evaluated site finish dates are not equal.");
			Assert.That(siteQueryServiceResult.TotalWorksCount, Is.EqualTo(siteWorksCount), "The evaluated site works count are not equal.");
		}

		[Test]
		public async Task GetSiteAsync_ShouldReturnCorrectSiteWorks_WithValidMethodArguments()
		{
			var site = TestSites.First(s => s.Id == 2);
			var works = TestWorks
				.Where(w => w.SiteId == site.Id)
				.Select(w => new WorkViewModel()
				{
					Id = w.Id,
					WorkName = w.WorkType.Name,
					Description = w.Description,
					CarryOutDate = w.CarryOutDate,
					Stage = w.Stage.Name,
					Contractor = w.Contractor.Name,
					Quantity = w.Quantity,
					Unit = w.Unit.Type,
					CostPerUnit = w.CostPerUnit,
					TotalCost = w.TotalCost,
					Creator = w.Creator.UserName
				});

			var siteQueryServiceResult = await _constructionSiteService.GetSiteAsync(site.Id, "Second Stage", "05/01/2025", Oldest);

			if (siteQueryServiceResult.TotalWorksCount == works.Count())
			{
				foreach (var work in works)
				{
					var workResult = siteQueryServiceResult.Works.First(w => w.Id == work.Id);

					Assert.Multiple(() =>
					{
						Assert.That(workResult.Id, Is.EqualTo(work.Id), "The evaluated work ids are not equal.");
						Assert.That(workResult.WorkName, Is.EqualTo(work.WorkName), "The evaluated work names are not the same.");
						Assert.That(workResult.Description, Is.EqualTo(work.Description), "The evaluated work descriptions are not the same.");
						Assert.That(workResult.CarryOutDate, Is.EqualTo(work.CarryOutDate), "The evaluated work carry out dates are not equal.");
						Assert.That(workResult.Stage, Is.EqualTo(work.Stage), "The evaluated work stages names are not the same.");
						Assert.That(workResult.Contractor, Is.EqualTo(work.Contractor), "The evaluated work contractors are not the same.");
						Assert.That(workResult.Quantity, Is.EqualTo(work.Quantity), "The evaluated work quantities are not equal.");
						Assert.That(workResult.Unit, Is.EqualTo(work.Unit), "The evaluated work units are not the same.");
						Assert.That(workResult.CostPerUnit, Is.EqualTo(work.CostPerUnit), "The evaluated work cost per units are not equal.");
						Assert.That(workResult.TotalCost, Is.EqualTo(work.TotalCost), "The evaluated work total costs are not equal.");
						Assert.That(workResult.Creator, Is.EqualTo(work.Creator), "The evaluated work creators are not the same.");
					});
				}
			}
		}
	}
}