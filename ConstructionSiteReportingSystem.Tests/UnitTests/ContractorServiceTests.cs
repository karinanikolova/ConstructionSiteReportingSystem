using ConstructionSiteReportingSystem.Core.Models.Suggest;
using ConstructionSiteReportingSystem.Core.Services;
using ConstructionSiteReportingSystem.Core.Services.Contracts;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities.Contracts;

namespace ConstructionSiteReportingSystem.Tests.UnitTests
{
	[TestFixture]
	public class ContractorServiceTests : UnitTestsBase
	{
		private IContractorService _contractorService;
		private IRepository _testRepository;

		[OneTimeSetUp]
		public void Setup()
		{
			_testRepository = new Repository(_dbContext);
			_contractorService = new ContractorService(_testRepository);
		}

		[Test]
		public async Task GetContractorsForReviewAsync_ShouldReturnAllContractorsForReview()
		{
			var contractors = TestContractors.Where(c => !c.IsApproved).OrderBy(c => c.Id).ToArray();
			var contractorsResult = await _contractorService.GetContractorsForReviewAsync();

			var contractorsCount = contractors.Count();
			var contractorsResultCount = contractorsResult.Count();

			Assert.That(contractorsResult, Is.Not.Null, "The tested service returned a null result for contractors for review.");
			Assert.That(contractorsCount, Is.EqualTo(contractorsResultCount), "The evaluated collections count are not equal.");

			if (contractorsCount == contractorsResultCount)
			{
				int i = default;

				foreach (var contractorResult in contractorsResult)
				{
					Assert.That(contractorResult.Id, Is.EqualTo(contractors[i].Id), "The evaluated contractor ids are not equal.");
					Assert.That(contractorResult.Name, Is.EqualTo(contractors[i++].Name), "The evaluated contractor names are not the same.");
				}
			}
		}

		[Test]
		public async Task ApproveContractorAsync_ShouldApproveSuccessfully_WithValidContractorId()
		{
			var contractor = TestContractors.First(c => !c.IsApproved);

			await _contractorService.ApproveContractorAsync(contractor.Id);

			Assert.That(contractor.IsApproved, Is.True);
		}

		[Test]
		public async Task AreThereContractorsToApproveAsync_ShouldReturnTrue()
		{
			var areThereContractorsToBeApproved = TestContractors.Any(c => !c.IsApproved);

			var areThereContractorsToBeApprovedResult = await _contractorService.AreThereContractorsToApproveAsync();

			Assert.That(areThereContractorsToBeApprovedResult, Is.EqualTo(areThereContractorsToBeApproved));
		}

		[Test]
		public async Task RemoveContractorAsync_ShouldRemoveSuccessfully_WithValidContractorId()
		{
			var contractorIdToRemove = TestContractors.First(c => !c.IsApproved).Id;
			var contractorsCountBeforeRemoving = TestContractors.Where(c => !c.IsApproved).Count();

			await _contractorService.RemoveContractorAsync(contractorIdToRemove);

			var contractorsAfterRemoving = await _contractorService.GetContractorsForReviewAsync();

			Assert.Multiple(() =>
			{
				Assert.That(contractorsAfterRemoving.Count(), Is.EqualTo(contractorsCountBeforeRemoving - 1), "The contractor has not been removed from the database.");
				Assert.That(contractorsAfterRemoving.FirstOrDefault(c => c.Id == contractorIdToRemove), Is.Null);
			});
		}

		[Test]
		public async Task GetContractorAddFormModelByIdAsync_ShouldReturnCorrectModel_WithValidContractorId()
		{
			var contractor = TestContractors.First(c => c.Id == 3);

			var contractorResult = await _contractorService.GetContractorAddFormModelByIdAsync(contractor.Id);

			Assert.That(contractorResult, Is.Not.Null, "The tested service returned a null result.");
			Assert.That(contractorResult.Name, Is.EqualTo(contractor.Name), "The evaluated contractor names are not the same.");
		}

		[Test]
		public async Task EditContractorAsync_ShoulEditSuccessfully_WithValidMethodArguments()
		{
			var contractorId = TestContractors.First().Id;
			var contractorAddFormModel = new ContractorAddFormModel()
			{
				Name = "Edited Contractor Name"
			};

			await _contractorService.EditContractorAsync(contractorId, contractorAddFormModel);
			var contractorAfterEdit = await _contractorService.GetContractorAddFormModelByIdAsync(contractorId);

			Assert.That(contractorAfterEdit!.Name, Is.EqualTo(contractorAddFormModel.Name));
		}

		[Test]
		public async Task DoesUnapprovedContractorExistAsync_ShoulReturnTrue_WithValidContractorId()
		{
			var unapprovedContractorId = TestContractors.First(c => !c.IsApproved).Id;

			var doesUnapprovedContractorExist = await _contractorService.DoesUnapprovedContractorExistAsync(unapprovedContractorId);

			Assert.That(doesUnapprovedContractorExist, Is.True);
		}
	}
}