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

		[HttpGet]
		public async Task<IActionResult> AddTask()
		{
			var statuses = _taskService.GetAllStatusesAsInt();

			var taskModel = new TaskAddFormModel()
			{
				Statuses = statuses
			};

			return View(taskModel);
		}

		[HttpPost]
		public async Task<IActionResult> AddTask(TaskAddFormModel taskModel)
		{
			if (_taskService.DoesStatusExist(taskModel.StatusId) == false)
			{
				ModelState.AddModelError(nameof(taskModel.StatusId), "Task status does not exist");
			}

			if (!ModelState.IsValid)
			{
				taskModel.Statuses = _taskService.GetAllStatusesAsInt();

				return View(taskModel);
			}

			var userId = User.Id();

			await _taskService.CreateTaskAsync(taskModel, userId);

			return RedirectToAction(nameof(All));
		}

		[HttpGet]
		public async Task<IActionResult> EditTask(int id)
		{
			if (await _taskService.DoesTaskExistAsync(id) == false)
			{
				return BadRequest();
			}

			var task = await _taskService.GetTaskEditFormModelByIdAsync(id);

			if (User.Id() != task!.CreatorId)
			{
				return Unauthorized();
			}

			return View(task);
		}

		[HttpPost]
		public async Task<IActionResult> EditTask(int id, TaskEditFormModel taskModel)
		{
			if (await _taskService.DoesTaskExistAsync(id) == false)
			{
				return BadRequest();
			}

			if (User.Id() != taskModel!.CreatorId)
			{
				return Unauthorized();
			}

			if (_taskService.DoesStatusExist(taskModel.StatusId) == false)
			{
				ModelState.AddModelError(nameof(taskModel.StatusId), "Task status does not exist");
			}

			if (!ModelState.IsValid)
			{
				taskModel.Statuses = _taskService.GetAllStatusesAsInt();

				return View(taskModel);
			}

			await _taskService.EditTaskAsync(id, taskModel);

			return RedirectToAction(nameof(All));
		}

		[HttpGet]
		public async Task<IActionResult> DeleteTask(int id)
		{
			if (await _taskService.DoesTaskExistAsync(id) == false)
			{
				return BadRequest();
			}

			var task = await _taskService.GetTaskViewModelByIdAsync(id);

			if (User.Id() != task!.Creator)
			{
				return Unauthorized();
			}

			return View(task);
		}

		[HttpPost]
		public async Task<IActionResult> DeleteTask(int id, TaskViewModel taskModel)
		{
			if (await _taskService.DoesTaskExistAsync(id) == false)
			{
				return BadRequest();
			}

			if (User.Id() != taskModel.Creator)
			{
				return Unauthorized();
			}

			await _taskService.DeleteTaskAsync(id);

			return RedirectToAction(nameof(All));
		}
	}
}
