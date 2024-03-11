using Microsoft.AspNetCore.Mvc;

namespace ConstructionSiteReportingSystem.Controllers
{
    public class TaskController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
