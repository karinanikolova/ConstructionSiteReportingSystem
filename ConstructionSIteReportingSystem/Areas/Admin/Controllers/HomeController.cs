using ConstructionSiteReportingSystem.Core.Services;
using ConstructionSiteReportingSystem.Core.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionSiteReportingSystem.Areas.Admin.Controllers
{
	public class HomeController : AdminBaseController
    {
		private readonly ILogger<ContractorController> _logger;
		private readonly IHomeService _homeService;

        public HomeController(ILogger<ContractorController> logger, IHomeService homeService)
        {
			_logger = logger;
			_homeService = homeService;
		}

        [HttpGet]
		public async Task<IActionResult> Index()
		{
            var forReviewViewModel = await _homeService.GetForReviewViewModelAsync();

            return View(forReviewViewModel);
        }
    }
}