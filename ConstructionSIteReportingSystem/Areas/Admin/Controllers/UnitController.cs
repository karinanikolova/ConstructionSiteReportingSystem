using ConstructionSiteReportingSystem.Core.Models.Suggest;
using ConstructionSiteReportingSystem.Core.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionSiteReportingSystem.Areas.Admin.Controllers
{
	public class UnitController : AdminBaseController
	{
		private readonly ILogger<UnitController> _logger;
		private readonly IUnitService _unitService;
		private readonly ISuggestService _suggestService;

		public UnitController(ILogger<UnitController> logger, IUnitService unitService, ISuggestService suggestService)
		{
			_logger = logger;
			_unitService = unitService;
			_suggestService = suggestService;
		}

		[HttpGet]
		public async Task<IActionResult> ApproveUnits()
		{
			var unitModels = await _unitService.GetUnitsForReviewAsync();

			if (!unitModels.Any())
			{
				return BadRequest();
			}

			return View(unitModels);
		}

		[HttpPost]
		public async Task<IActionResult> ApproveUnit(int id)
		{
			await _unitService.ApproveUnitAsync(id);

			if (await _unitService.AreThereUnitsToApproveAsync())
			{
				return RedirectToAction(nameof(ApproveUnits));
			}

			return RedirectToAction("Index", "Home", new { area = "Admin" });
		}

		[HttpGet]
		public async Task<IActionResult> EditUnit(int id)
		{
			if (await _unitService.DoesUnapprovedUnitExistAsync(id) == false)
			{
				return BadRequest();
			}

			var unitModel = await _unitService.GetUnitAddFormModelByIdAsync(id);

			return View(unitModel);
		}

		[HttpPost]
		public async Task<IActionResult> EditUnit(int id, UnitAddFormModel unitModel)
		{
			if (await _unitService.DoesUnapprovedUnitExistAsync(id) == false)
			{
				return BadRequest();
			}

			if (string.IsNullOrWhiteSpace(unitModel.Type))
			{
				ModelState.AddModelError(nameof(unitModel.Type), "A measurement unit type cannot contain only white space characters");
			}
			else if (await _suggestService.DoesUnitTypeExistAsync(unitModel.Type) == true)
			{
				ModelState.AddModelError(nameof(unitModel.Type), "A measurement unit type with the given name already exists");
			}

			if (!ModelState.IsValid)
			{
				return View(unitModel);
			}

			await _unitService.EditUnitAsync(id, unitModel);

			if (await _unitService.AreThereUnitsToApproveAsync())
			{
				return RedirectToAction(nameof(ApproveUnits));
			}

			return RedirectToAction("Index", "Home", new { area = "Admin" });
		}

		[HttpPost]
		public async Task<IActionResult> RemoveUnit(int id)
		{
			await _unitService.RemoveUnitAsync(id);

			if (await _unitService.AreThereUnitsToApproveAsync())
			{
				return RedirectToAction(nameof(ApproveUnits));
			}

			return RedirectToAction("Index", "Home", new { area = "Admin" });
		}
	}
}