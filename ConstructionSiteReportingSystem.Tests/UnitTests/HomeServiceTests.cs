using ConstructionSiteReportingSystem.Core.Services;
using ConstructionSiteReportingSystem.Core.Services.Contracts;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities.Contracts;

namespace ConstructionSiteReportingSystem.Tests.UnitTests
{
	[TestFixture]
	public class HomeServiceTests : UnitTestsBase
	{
		private IHomeService _homeService;
		private IRepository _testRepository;

		[OneTimeSetUp]
		public void Setup()
		{
			_testRepository = new Repository(_dbContext);
			_homeService = new HomeService(_testRepository);
		}

		[Test]
		public async Task SitesForPreviewAsync_ShouldReturnSitesForPreview()
		{
			var sites = TestSites.Take(3).ToArray();

			var sitesResult = await _homeService.SitesForPreviewAsync();

			Assert.That(sitesResult, Is.Not.Null, "The tested service returned a null result.");
			Assert.That(sitesResult.Count(), Is.EqualTo(sites.Length), "The evaluated site counts are not equal.");

			int i = default;

			foreach (var siteResult in sitesResult.OrderBy(s => s.Id))
			{
				Assert.Multiple(() =>
				{
					Assert.That(siteResult.Id, Is.EqualTo(sites[i].Id), "The evaluated site ids are not equal.");
					Assert.That(siteResult.Name, Is.EqualTo(sites[i].Name), "The evaluated site names are not the same.");
					Assert.That(siteResult.ImageUrl, Is.EqualTo(sites[i++].ImageUrl), "The evaluated site image URLs are not the same.");
				});
			}
		}

		[Test]
		public async Task GetForReviewViewModelAsync_ShouldReturnViewModelForPreview()
		{
			var areThereContractorsForReview = TestContractors.Any(c => !c.IsApproved);
			var areThereStagesForReview = TestStages.Any(s => !s.IsApproved);
			var areThereUnitsForReview = TestUnits.Any(u => !u.IsApproved);
			var areThereWorkTypesForReview = TestWorkTypes.Any(wt => !wt.IsApproved);

			var forReviewViewModel = await _homeService.GetForReviewViewModelAsync();

			Assert.That(forReviewViewModel, Is.Not.Null, "The tested service returned a null result.");
			Assert.Multiple(() =>
			{
				Assert.That(forReviewViewModel.AreThereContractorsForReview, Is.EqualTo(areThereContractorsForReview), "The evaluated boolean values regarding contractors for review are not the same.");
				Assert.That(forReviewViewModel.AreThereStagesForReview, Is.EqualTo(areThereStagesForReview), "The evaluated boolean values regarding stages for review are not the same.");
				Assert.That(forReviewViewModel.AreThereUnitsForReview, Is.EqualTo(areThereUnitsForReview), "The evaluated boolean values regarding units for review are not the same.");
				Assert.That(forReviewViewModel.AreThereWorkTypesForReview, Is.EqualTo(areThereWorkTypesForReview), "The evaluated boolean values regarding work types for review are not the same.");
			});
		}
	}
}