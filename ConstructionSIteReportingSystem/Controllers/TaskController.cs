using ConstructionSiteReportingSystem.Core.Models.Task;
using ConstructionSiteReportingSystem.Core.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ConstructionSiteReportingSystem.Controllers
{
	public class TaskController : BaseController
    {
		private readonly ILogger<TaskController> _logger;
		private readonly ITaskService _taskService;

		public TaskController(ILogger<TaskController> logger, ITaskService taskService)
		{
			_logger = logger;
			_taskService = taskService;
		}

		[HttpGet]
		public async Task<IActionResult> All([FromQuery] AllTasksQueryModel model)
        {
			var userId = User.Id();

			var tasks = await _taskService.GetAllUserTasksAsync(
				userId,
				model.Status,
				model.SearchTerm,
				model.Sorting,
				model.CurrentPage,
				AllTasksQueryModel.TasksPerPage);

			model.TotalTasksCount = tasks.TotalTasksCount;
			model.Tasks = tasks.Tasks;
			model.Statuses = _taskService.GetAllStatusesAsString();

            return View(model);
        }

		
    }
}
