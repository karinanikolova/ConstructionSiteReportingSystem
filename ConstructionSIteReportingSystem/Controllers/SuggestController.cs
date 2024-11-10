using ConstructionSiteReportingSystem.Core.Models.Suggest;
using ConstructionSiteReportingSystem.Core.Services.Contracts;
using ConstructionSiteReportingSystem.Infrastructure.Constants;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.RegularExpressions;

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
			if (string.IsNullOrWhiteSpace(stageModel.Name))
			{
				ModelState.AddModelError(nameof(stageModel.Name), "A construction stage name cannot contain only white space characters");

				return View(stageModel);
			}

			stageModel.Name = stageModel.Name.Trim();

			Regex stageNameRegex = new Regex(DataConstants.Stage.NameMatchRegex);

			if (!stageNameRegex.IsMatch(stageModel.Name))
			{
				ModelState.AddModelError(nameof(stageModel.Name), "The construction stage name suggestion is not valid");

				return View(stageModel);
			}

			if (await _suggestService.DoesStageNameExistAsync(stageModel.Name) == true)
			{
				ModelState.AddModelError(nameof(stageModel.Name), "A construction stage with the given name already exists");
			}

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
			if (string.IsNullOrWhiteSpace(unitModel.Type))
			{
				ModelState.AddModelError(nameof(unitModel.Type), "A measurement unit type cannot contain only white space characters");

				return View(unitModel);
			}

			unitModel.Type = unitModel.Type.Trim();

			Regex unitTypeRegex = new Regex(DataConstants.Unit.TypeMatchRegex);

			if (!unitTypeRegex.IsMatch(unitModel.Type))
			{
				ModelState.AddModelError(nameof(unitModel.Type), "The measurement unit type suggestion is not valid");

				return View(unitModel);
			}

			if (await _suggestService.DoesUnitTypeExistAsync(unitModel.Type) == true)
			{
				ModelState.AddModelError(nameof(unitModel.Type), "A measurement unit type with the given name already exists");
			}

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
			if (string.IsNullOrWhiteSpace(workTypeModel.Name))
			{
				ModelState.AddModelError(nameof(workTypeModel.Name), "A construction and assembly work type name cannot contain only white space characters");

				return View(workTypeModel);
			}

			workTypeModel.Name = workTypeModel.Name.Trim();

			Regex workTypeNameRegex = new Regex(DataConstants.WorkType.NameMatchRegex);

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

			bool isUserAdmin = User.IsAdmin();

			await _suggestService.CreateWorkTypeAsync(workTypeModel, isUserAdmin);

			return RedirectToAction("All", "ConstructionSite");
		}
	}
}