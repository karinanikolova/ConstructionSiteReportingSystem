using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionSiteReportingSystem.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {

    }
}
