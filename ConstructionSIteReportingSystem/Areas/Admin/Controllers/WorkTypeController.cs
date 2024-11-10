using ConstructionSiteReportingSystem.Core.Models.Suggest;
using ConstructionSiteReportingSystem.Core.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using static ConstructionSiteReportingSystem.Infrastructure.Constants.DataConstants.WorkType;

namespace ConstructionSiteReportingSystem.Areas.Admin.Controllers
{
	public class WorkTypeController : AdminBaseController
	{
		private readonly ILogger<WorkTypeController> _logger;
		private readonly IWorkTypeService _workTypeService;
		private readonly ISuggestService _suggestService;

		public WorkTypeController(ILogger<WorkTypeController> logger, IWorkTypeService workTypeService, ISuggestService suggestService)
		{
			_logger = logger;
			_workTypeService = workTypeService;
			_suggestService = suggestService;
		}

		[HttpGet]
		public async Task<IActionResult> ApproveWorkTypes()
		{
			var workTypeModels = await _workTypeService.GetWorkTypesForReviewAsync();

			if (!workTypeModels.Any())
			{
				return BadRequest();
			}

			return View(workTypeModels);
		}

		[HttpPost]
		public async Task<IActionResult> ApproveWorkType(int id)
		{
			await _workTypeService.ApproveWorkTypeAsync(id);

			if (await _workTypeService.AreThereWorkTypesToApproveAsync())
			{
				return RedirectToAction(nameof(ApproveWorkTypes));
			}

			return RedirectToAction("Index", "Home", new { area = "Admin" });
		}

		[HttpGet]
		public async Task<IActionResult> EditWorkType(int id)
		{
			if (await _workTypeService.DoesUnapprovedWorkTypeExistAsync(id) == false)
			{
				return BadRequest();
			}

			var workTypeModel = await _workTypeService.GetWorkTypeAddFormModelByIdAsync(id);

			return View(workTypeModel);
		}

		[HttpPost]
		public async Task<IActionResult> EditWorkType(int id, WorkTypeAddFormModel workTypeModel)
		{
			if (await _workTypeService.DoesUnapprovedWorkTypeExistAsync(id) == false)
			{
				return BadRequest();
			}

			if (string.IsNullOrWhiteSpace(workTypeModel.Name))
			{
				ModelState.AddModelError(nameof(workTypeModel.Name), "A construction and assembly work type name cannot contain only white space characters");

				return View(workTypeModel);
			}

			workTypeModel.Name = workTypeModel.Name.Trim();

			Regex workTypeNameRegex = new Regex(NameMatchRegex);

			if (!workTypeNameRegex.IsMatch(workTypeModel.Name))
			{
				ModelState.AddModelError(nameof(workTypeModel.Name), "The construction and assembly work type name suggestion is not valid");

				return View(workTypeModel);
			}

			if (await _suggestService.DoesWorkTypeNameExistAsync(workTypeModel.Name) == true)
			{
				ModelState.AddModelError(nameof(workTypeModel.Name), "A construction and assembly work type with the given name already exists");
			}

			if (!ModelState.IsValid)
			{
				return View(workTypeModel);
			}

			await _workTypeService.EditWorkTypeAsync(id, workTypeModel);

			if (await _workTypeService.AreThereWorkTypesToApproveAsync())
			{
				return RedirectToAction(nameof(ApproveWorkTypes));
			}

			return RedirectToAction("Index", "Home", new { area = "Admin" });
		}

		[HttpPost]
		public async Task<IActionResult> RemoveWorkType(int id)
		{
			await _workTypeService.RemoveWorkTypeAsync(id);

			if (await _workTypeService.AreThereWorkTypesToApproveAsync())
			{
				return RedirectToAction(nameof(ApproveWorkTypes));
			}

			return RedirectToAction("Index", "Home", new { area = "Admin" });
		}
	}
}