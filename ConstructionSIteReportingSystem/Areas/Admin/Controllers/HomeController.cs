using Microsoft.AspNetCore.Mvc;

namespace ConstructionSiteReportingSystem.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}