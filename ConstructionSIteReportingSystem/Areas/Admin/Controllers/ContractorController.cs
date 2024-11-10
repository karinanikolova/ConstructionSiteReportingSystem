using ConstructionSiteReportingSystem.Core.Models.Suggest;
using ConstructionSiteReportingSystem.Core.Services.Contracts;
using ConstructionSiteReportingSystem.Infrastructure.Constants;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace ConstructionSiteReportingSystem.Areas.Admin.Controllers
{
	public class ContractorController : AdminBaseController
	{
		private readonly ILogger<ContractorController> _logger;
		private readonly IContractorService _contractorService;
		private readonly ISuggestService _suggestService;

		public ContractorController(ILogger<ContractorController> logger, IContractorService contractorService, ISuggestService suggestService)
		{
			_logger = logger;
			_contractorService = contractorService;
			_suggestService = suggestService;
		}

		[HttpGet]
		public async Task<IActionResult> ApproveContractors()
		{
			var contractorModels = await _contractorService.GetContractorsForReviewAsync();

			if (!contractorModels.Any())
			{
				return BadRequest();
			}

			return View(contractorModels);
		}

		[HttpPost]
		public async Task<IActionResult> ApproveContractor(int id)
		{
			await _contractorService.ApproveContractorAsync(id);

			if (await _contractorService.AreThereContractorsToApproveAsync())
			{
				return RedirectToAction(nameof(ApproveContractors));
			}

			return RedirectToAction("Index", "Home", new { area = "Admin" });
		}

		[HttpGet]
		public async Task<IActionResult> EditContractor(int id)
		{
			if (await _contractorService.DoesUnapprovedContractorExistAsync(id) == false)
			{
				return BadRequest();
			}

			var contractorModel = await _contractorService.GetContractorAddFormModelByIdAsync(id);

			return View(contractorModel);
		}

		[HttpPost]
		public async Task<IActionResult> EditContractor(int id, ContractorAddFormModel contractorModel)
		{
			if (await _contractorService.DoesUnapprovedContractorExistAsync(id) == false)
			{
				return BadRequest();
			}

			if (string.IsNullOrWhiteSpace(contractorModel.Name))
			{
				ModelState.AddModelError(nameof(contractorModel.Name), "A contractor name cannot contain only white space characters");

				return View(contractorModel);
			}

			contractorModel.Name = contractorModel.Name.Trim();

			Regex contractorNameRegex = new Regex(DataConstants.Contractor.NameMatchRegex);

			if (!contractorNameRegex.IsMatch(contractorModel.Name))
			{
				ModelState.AddModelError(nameof(contractorModel.Name), "The contractor name suggestion is not valid");

				return View(contractorModel);
			}

			if (await _suggestService.DoesContractorNameExistAsync(contractorModel.Name) == true)
			{
				ModelState.AddModelError(nameof(contractorModel.Name), "A contractor with the given name already exists");
			}

			if (!ModelState.IsValid)
			{
				return View(contractorModel);
			}

			await _contractorService.EditContractorAsync(id, contractorModel);

			if (await _contractorService.AreThereContractorsToApproveAsync())
			{
				return RedirectToAction(nameof(ApproveContractors));
			}

			return RedirectToAction("Index", "Home", new { area = "Admin" });
		}

		[HttpPost]
		public async Task<IActionResult> RemoveContractor(int id)
		{
			await _contractorService.RemoveContractorAsync(id);

			if (await _contractorService.AreThereContractorsToApproveAsync())
			{
				return RedirectToAction(nameof(ApproveContractors));
			}

			return RedirectToAction("Index", "Home", new { area = "Admin" });
		}
	}
}