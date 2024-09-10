using ConstructionSiteReportingSystem.Core.Models.Suggest;
using ConstructionSiteReportingSystem.Core.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionSiteReportingSystem.Areas.Admin.Controllers
{
	public class StageController : AdminBaseController
	{
		private readonly ILogger<StageController> _logger;
		private readonly IStageService _stageService;
		private readonly ISuggestService _suggestService;

		public StageController(ILogger<StageController> logger, IStageService stageService, ISuggestService suggestService)
		{
			_logger = logger;
			_stageService = stageService;
			_suggestService = suggestService;
		}

		[HttpGet]
		public async Task<IActionResult> ApproveStages()
		{
			var stageModels = await _stageService.GetStagesForReviewAsync();

			if (!stageModels.Any())
			{
				return BadRequest();
			}

			return View(stageModels);
		}

		[HttpPost]
		public async Task<IActionResult> ApproveStage(int id)
		{
			await _stageService.ApproveStageAsync(id);

			if (await _stageService.AreThereStagesToApproveAsync())
			{
				return RedirectToAction(nameof(ApproveStages));
			}

			return RedirectToAction("Index", "Home", new { area = "Admin" });
		}

		[HttpGet]
		public async Task<IActionResult> EditStage(int id)
		{
			if (await _stageService.DoesUnapprovedStageExistAsync(id) == false)
			{
				return BadRequest();
			}

			var stageModel = await _stageService.GetStageAddFormModelByIdAsync(id);

			return View(stageModel);
		}

		[HttpPost]
		public async Task<IActionResult> EditStage(int id, StageAddFormModel stageModel)
		{
			if (await _stageService.DoesUnapprovedStageExistAsync(id) == false)
			{
				return BadRequest();
			}

			if (string.IsNullOrWhiteSpace(stageModel.Name))
			{
				ModelState.AddModelError(nameof(stageModel.Name), "A construction stage name cannot contain only white space characters");
			}
			else if (await _suggestService.DoesStageNameExistAsync(stageModel.Name) == true)
			{
				ModelState.AddModelError(nameof(stageModel.Name), "A construction stage with the given name already exists");
			}

			if (!ModelState.IsValid)
			{
				return View(stageModel);
			}

			await _stageService.EditStageAsync(id, stageModel);

			if (await _stageService.AreThereStagesToApproveAsync())
			{
				return RedirectToAction(nameof(ApproveStages));
			}

			return RedirectToAction("Index", "Home", new { area = "Admin" });
		}

		[HttpPost]
		public async Task<IActionResult> RemoveStage(int id)
		{
			await _stageService.RemoveStageAsync(id);

			if (await _stageService.AreThereStagesToApproveAsync())
			{
				return RedirectToAction(nameof(ApproveStages));
			}

			return RedirectToAction("Index", "Home", new { area = "Admin" });
		}
	}
}