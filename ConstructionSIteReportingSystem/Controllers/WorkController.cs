using ConstructionSiteReportingSystem.Core.Contracts;
using ConstructionSiteReportingSystem.Core.Models.Site;
using ConstructionSiteReportingSystem.Core.Models.Work;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Security.Claims;
using static ConstructionSiteReportingSystem.Core.Constants.ValidationConstants;

namespace ConstructionSiteReportingSystem.Controllers
{
	public class WorkController : BaseController
	{
		private readonly ILogger<WorkController> _logger;
		private readonly IWorkService _workService;

		public WorkController(ILogger<WorkController> logger, IWorkService workService)
		{
			_logger = logger;
			_workService = workService;
		}

		[HttpGet]
		public async Task<IActionResult> AddWork()
		{
			var sites = await _workService.GetAllSitesAsync();
			var workTypes = await _workService.GetAllWorkTypesAsync();
			var stages = await _workService.GetAllStagesAsync();
			var contractors = await _workService.GetAllContractorsAsync();
			var units = await _workService.GetAllUnitsAsync();

			var workModel = new WorkFormModel()
			{
				Sites = sites,
				WorkTypes = workTypes,
				Stages = stages,
				Contractors = contractors,
				Units = units
			};

			return View(workModel);
		}

		[HttpPost]
		public async Task<IActionResult> AddWork(WorkFormModel workModel)
		{
			if (await _workService.DoesSiteExistAsync(workModel.SiteId) == false)
			{
				ModelState.AddModelError(nameof(workModel.SiteId), "Construction site does not exist");
			}

			if (await _workService.DoesWorkTypeExistAsync(workModel.WorkTypeId) == false)
			{
				ModelState.AddModelError(nameof(workModel.WorkTypeId), "Construction and assembly work type does not exist");
			}

			if (await _workService.DoesStageExistAsync(workModel.StageId) == false)
			{
				ModelState.AddModelError(nameof(workModel.StageId), "Construction stage does not exist");
			}

			if (await _workService.DoesContractorExistAsync(workModel.ContractorId) == false)
			{
				ModelState.AddModelError(nameof(workModel.ContractorId), "Contractor does not exist");
			}

			if (await _workService.DoesUnitExistAsync(workModel.UnitId) == false)
			{
				ModelState.AddModelError(nameof(workModel.UnitId), "Measurement unit does not exist");
			}

			DateTime date;
			bool isDateValid = DateTime.TryParseExact(workModel.CarryOutDate, DateTimePreferredFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

			if (!isDateValid)
			{
				ModelState.AddModelError(nameof(workModel.CarryOutDate), "The specified date is not valid");
			}

			if (!ModelState.IsValid)
			{
				//if (ModelState["SiteId"].Errors.Count > 0)
				//{

				//}

				if (ModelState.GetValidationState("SiteId") == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid)
				{
					workModel.Sites = await _workService.GetAllSitesAsync();
				}

				if (ModelState.GetValidationState("WorkTypeId") == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid)
				{
					workModel.WorkTypes = await _workService.GetAllWorkTypesAsync();
				}

				if (ModelState.GetValidationState("StageId") == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid)
				{
					workModel.Stages = await _workService.GetAllStagesAsync();
				}

				if (ModelState.GetValidationState("ContractorId") == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid)
				{
					workModel.Contractors = await _workService.GetAllContractorsAsync();
				}

				if (ModelState.GetValidationState("UnitId") == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid)
				{
					workModel.Units = await _workService.GetAllUnitsAsync();
				}

				if (ModelState.GetValidationState("CarryOutDate") == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid)
				{
					workModel.CarryOutDate = ConvertDateToString(DateTime.UtcNow);
				}

				return View(workModel);
			}

			var userId = GetCurrentUserId();

			var siteId = await _workService.CreateWorkAsync(workModel, date, userId);

			//To be continued -> SiteQueryModel
			return RedirectToAction("Site", "ConstructionSite", new {id = siteId, model = new SiteQueryModel()});
		}

		private string GetCurrentUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);

		private static string ConvertDateToString(DateTime date)
		{
			return date.ToString(DateTimePreferredFormat, CultureInfo.InvariantCulture);
		}
	}
}
