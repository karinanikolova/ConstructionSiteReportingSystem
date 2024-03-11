using Microsoft.AspNetCore.Mvc;

namespace ConstructionSiteReportingSystem.Controllers
{
    public class ReportController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
