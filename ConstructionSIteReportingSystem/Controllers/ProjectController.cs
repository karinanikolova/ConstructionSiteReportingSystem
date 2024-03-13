using ConstructionSiteReportingSystem.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionSiteReportingSystem.Controllers
{
    public class ProjectController : BaseController
    {
		private readonly ILogger<ProjectController> _logger;
		private readonly IProjectService _projectService;

		public ProjectController(ILogger<ProjectController> logger, IProjectService projectService)
		{
			_logger = logger;
			_projectService = projectService;
		}

		[HttpGet]
        public async Task<IActionResult> All()
        {
			var models = await _projectService.AllProjectsAsync();

            return View(models);
        }
    }
}
