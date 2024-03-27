using ConstructionSiteReportingSystem.Core.Contracts;
using ConstructionSiteReportingSystem.Core.Models.Work;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

		private string GetCurrentUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);
	}
}
