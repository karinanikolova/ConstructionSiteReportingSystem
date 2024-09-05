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
	}
}
