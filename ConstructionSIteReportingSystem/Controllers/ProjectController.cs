using Microsoft.AspNetCore.Mvc;

namespace ConstructionSiteReportingSystem.Controllers
{
    public class ProjectController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
