using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ConstructionSiteReportingSystem.Models;
using ConstructionSiteReportingSystem.Core.Models.Home;
using Microsoft.AspNetCore.Authorization;

namespace ConstructionSiteReportingSystem.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var model = new IndexViewModel();

            return View(model);
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
