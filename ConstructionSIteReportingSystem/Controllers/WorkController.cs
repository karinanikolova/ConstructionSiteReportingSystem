﻿using ConstructionSiteReportingSystem.Core.Models.Site;
using ConstructionSiteReportingSystem.Core.Models.Work;
using ConstructionSiteReportingSystem.Core.Services.Contracts;
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
		private readonly IConstructionSiteService _constructionSiteService;

		public WorkController(ILogger<WorkController> logger, IWorkService workService, IConstructionSiteService constructionSiteService)
		{
			_logger = logger;
			_workService = workService;
			_constructionSiteService = constructionSiteService;
		}

		[HttpGet]
		public async Task<IActionResult> AddWork()
		{
			var sites = await _workService.GetAllSiteServiceModelsAsync();
			var workTypes = await _workService.GetAllWorkTypesAsync();
			var stages = await _workService.GetAllStagesAsync();
			var contractors = await _workService.GetAllContractorsAsync();
			var units = await _workService.GetAllUnitsAsync();

			var workModel = new WorkAddFormModel()
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
		public async Task<IActionResult> AddWork(WorkAddFormModel workModel)
		{
			if (await _constructionSiteService.DoesSiteExistAsync(workModel.SiteId) == false)
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

			if (!isDateValid || date.Year < DateTime.UtcNow.Year)
			{
				ModelState.AddModelError(nameof(workModel.CarryOutDate), "The specified date is not valid");
			}

			if (!ModelState.IsValid)
			{
				workModel.Sites = await _workService.GetAllSiteServiceModelsAsync();
				workModel.WorkTypes = await _workService.GetAllWorkTypesAsync();
				workModel.Stages = await _workService.GetAllStagesAsync();
				workModel.Contractors = await _workService.GetAllContractorsAsync();
				workModel.Units = await _workService.GetAllUnitsAsync();

				return View(workModel);
			}

			var userId = User.Id();

			var siteId = await _workService.CreateWorkAsync(workModel, date, userId);

			var siteInformation = await _constructionSiteService.GetSiteInformationAsync(siteId);

			return RedirectToAction("Site", "ConstructionSite", new {id = siteId, information = siteInformation, model = new SiteQueryModel()});
		}

		[HttpGet]
		public async Task<IActionResult> EditWork(int id)
		{
			if (await _workService.DoesWorkExistAsync(id) == false)
			{
				return BadRequest();
			}

			var work = await _workService.GetWorkEditFormModelByIdAsync(id);

			if (User.Id() != work!.CreatorId && User.IsAdmin() == false)
			{
				return Unauthorized();
			}

			return View(work);
		}

		[HttpPost]
		public async Task<IActionResult> EditWork(int id, WorkEditFormModel workModel)
		{
			if (await _workService.DoesWorkExistAsync(id) == false)
			{
				return BadRequest();
			}

			if (User.Id() != workModel.CreatorId && User.IsAdmin() == false)
			{
				return Unauthorized();
			}

			if (await _constructionSiteService.DoesSiteExistAsync(workModel.SiteId) == false)
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

			if (!isDateValid || date.Year < DateTime.UtcNow.Year)
			{
				ModelState.AddModelError(nameof(workModel.CarryOutDate), "The specified date is not valid");
			}

			if (!ModelState.IsValid)
			{
				workModel.Sites = await _workService.GetAllSiteServiceModelsAsync();
				workModel.WorkTypes = await _workService.GetAllWorkTypesAsync();
				workModel.Stages = await _workService.GetAllStagesAsync();
				workModel.Contractors = await _workService.GetAllContractorsAsync();
				workModel.Units = await _workService.GetAllUnitsAsync();

				return View(workModel);
			}

			await _workService.EditWorkAsync(id, workModel, date);

			var siteId = workModel.SiteId;

			var siteInformation = await _constructionSiteService.GetSiteInformationAsync(siteId);
			
			return RedirectToAction("Site", "ConstructionSite", new { id = siteId, information = siteInformation, model = new SiteQueryModel() });
		}

		[HttpGet]
		public async Task<IActionResult> DeleteWork(int id)
		{
			if (await _workService.DoesWorkExistAsync(id) == false)
			{
				return BadRequest();
			}

			var work = await _workService.GetWorkServiceModelByIdAsync(id);

			if (User.Id() != work!.CreatorId && User.IsAdmin() == false)
			{
				return Unauthorized();
			}

			return View(work);
		}

		[HttpPost]
		public async Task<IActionResult> DeleteWork(int id, WorkServiceModel workModel)
		{
			if (await _workService.DoesWorkExistAsync(id) == false)
			{
				return BadRequest();
			}

			if (User.Id() != workModel.CreatorId && User.IsAdmin() == false)
			{
				return Unauthorized();
			}

			await _workService.DeleteWorkAsync(id);

			var siteId = workModel.SiteId;

			var siteInformation = await _constructionSiteService.GetSiteInformationAsync(siteId);

			return RedirectToAction("Site", "ConstructionSite", new { id = siteId, information = siteInformation, model = new SiteQueryModel() });
		}
	}
}