using ConstructionSiteReportingSystem.Core.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionSiteReportingSystem.Areas.Admin.Controllers
{
	public class HomeController : AdminBaseController
    {
		private readonly ILogger<ForReviewController> _logger;
		private readonly IForReviewService _forReviewService;

        public HomeController(ILogger<ForReviewController> logger, IForReviewService forReviewService)
        {
			_logger = logger;
			_forReviewService = forReviewService;
		}

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var forReviewViewModel = await _forReviewService.GetForReviewViewModelAsync();

            return View(forReviewViewModel);
        }
    }
}