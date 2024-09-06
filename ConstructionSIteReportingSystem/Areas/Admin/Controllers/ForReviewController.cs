using ConstructionSiteReportingSystem.Core.Models.Suggest;
using ConstructionSiteReportingSystem.Core.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionSiteReportingSystem.Areas.Admin.Controllers
{
	public class ForReviewController : AdminBaseController
	{
		private readonly ILogger<ForReviewController> _logger;
		private readonly IForReviewService _forReviewService;

		public ForReviewController(ILogger<ForReviewController> logger, IForReviewService forReviewService)
		{
			_logger = logger;
			_forReviewService = forReviewService;
		}

		[HttpGet]
		public async Task<IActionResult> ApproveContractors()
		{
			var contractorModels = await _forReviewService.GetContractorsForReviewAsync();

			if (!contractorModels.Any())
			{
				return BadRequest();
			}

			return View(contractorModels);
		}

		[HttpPost]
		public async Task<IActionResult> ApproveContractor(int id)
		{
			await _forReviewService.ApproveContractorAsync(id);

			if (await _forReviewService.AreThereContractorsToApproveAsync())
			{
				return RedirectToAction(nameof(ApproveContractors));
			}

			return RedirectToAction("Index", "Home", new { area = "Admin" });
		}

		[HttpGet]
		public async Task<IActionResult> EditContractor(int id)
		{
			if (await _forReviewService.DoesUnapprovedContractorExistAsync(id) == false)
			{
				return BadRequest();
			}

			var contractorModel = await _forReviewService.GetContractorAddFormModelByIdAsync(id);

			return View(contractorModel);
		}

		[HttpPost]
		public async Task<IActionResult> EditContractor(int id, ContractorAddFormModel contractorModel)
		{
			if (await _forReviewService.DoesUnapprovedContractorExistAsync(id) == false)
			{
				return BadRequest();
			}

			if (!ModelState.IsValid)
			{
				return View(contractorModel);
			}

			await _forReviewService.EditContractorAsync(id, contractorModel);

			if (await _forReviewService.AreThereContractorsToApproveAsync())
			{
				return RedirectToAction(nameof(ApproveContractors));
			}

			return RedirectToAction("Index", "Home", new { area = "Admin" });
		}

		[HttpPost]
		public async Task<IActionResult> RemoveContractor(int id)
		{
			await _forReviewService.RemoveContractorAsync(id);

			if (await _forReviewService.AreThereContractorsToApproveAsync())
			{
				return RedirectToAction(nameof(ApproveContractors));
			}

			return RedirectToAction("Index", "Home", new { area = "Admin" });
		}
	}
}