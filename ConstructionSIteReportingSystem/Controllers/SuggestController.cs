using ConstructionSiteReportingSystem.Core.Models.Suggest;
using ConstructionSiteReportingSystem.Core.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ConstructionSiteReportingSystem.Controllers
{
	public class SuggestController : BaseController
	{
		private readonly ILogger<SuggestController> _logger;
		private readonly ISuggestService _suggestService;

        public SuggestController(ILogger<SuggestController> logger, ISuggestService suggestService)
        {
			_suggestService = suggestService;
			_logger = logger;
        }

        [HttpGet]
		public async Task<IActionResult> Contractor()
		{
			return View(new ContractorAddFormModel());
		}

		[HttpPost]
		public async Task<IActionResult> Contractor(ContractorAddFormModel contractorModel)
		{
			if (!ModelState.IsValid)
			{
				return View(contractorModel);
			}

			bool isUserAdmin = User.IsAdmin();

			await _suggestService.CreateContractorAsync(contractorModel, isUserAdmin);

			return RedirectToAction("All", "ConstructionSite");
		}

		[HttpGet]
		public async Task<IActionResult> Stage()
		{
			return View(new StageAddFormModel());
		}

		[HttpPost]
		public async Task<IActionResult> Stage(StageAddFormModel stageModel)
		{
			if (!ModelState.IsValid)
			{
				return View(stageModel);
			}

			bool isUserAdmin = User.IsAdmin();

			await _suggestService.CreateStageAsync(stageModel, isUserAdmin);

			return RedirectToAction("All", "ConstructionSite");
		}

		[HttpGet]
		public async Task<IActionResult> Unit()
		{
			return View(new UnitAddFormModel());
		}

		[HttpPost]
		public async Task<IActionResult> Unit(UnitAddFormModel unitModel)
		{
			if (!ModelState.IsValid)
			{
				return View(unitModel);
			}

			bool isUserAdmin = User.IsAdmin();

			await _suggestService.CreateUnitAsync(unitModel, isUserAdmin);

			return RedirectToAction("All", "ConstructionSite");
		}

		[HttpGet]
		public async Task<IActionResult> WorkType()
		{
			return View(new WorkTypeAddFormModel());
		}

		[HttpPost]
		public async Task<IActionResult> WorkType(WorkTypeAddFormModel workTypeModel)
		{
			if (!ModelState.IsValid)
			{
				return View(workTypeModel);
			}

			bool isUserAdmin = User.IsAdmin();

			await _suggestService.CreateWorkTypeAsync(workTypeModel, isUserAdmin);

			return RedirectToAction("All", "ConstructionSite");
		}
	}
}