using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static ConstructionSiteReportingSystem.Core.Constants.AdministratorConstants;

namespace ConstructionSiteReportingSystem.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRole)]
    public class AdminBaseController : Controller
    {

    }
}
