using ConstructionSiteReportingSystem.Core.Contracts;
using ConstructionSiteReportingSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ConstructionSiteReportingSystem.Controllers
{
	public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService _homeService;

        public HomeController(ILogger<HomeController> logger, IHomeService homeService)
        {
            _logger = logger;
            _homeService = homeService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var models = await _homeService.ProjectsForPreviewAsync();

            return View(models);
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
