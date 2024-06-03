using ConstructionSiteReportingSystem.Core.Models.Task;
using ConstructionSiteReportingSystem.Core.Models.Work;
using ConstructionSiteReportingSystem.Core.Services.Contracts;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities.Contracts;
using ConstructionSiteReportingSystem.Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;
using Task = ConstructionSiteReportingSystem.Infrastructure.Data.Models.Task;

namespace ConstructionSiteReportingSystem.Core.Services
{
	public class TaskService : ITaskService
	{
		private readonly IRepository _repository;

		public TaskService(IRepository repository)
		{
			_repository = repository;
		}

		public async Task<TaskQueryServiceModel> GetAllUserTasksAsync(string userId, string? searchStatus = null, string? searchTerm = null, DateSorting dateSorting = DateSorting.Newest, int currentPage = 1, int tasksPerPage = 1)
		{
			var tasks = _repository.AllReadOnly<Task>().Where(t => t.CreatorId == userId);
			var statuses = GetAllStatusesAsString();

			if (!string.IsNullOrWhiteSpace(searchStatus) && statuses.Any(s => s == searchStatus))
			{
				Status status;
				bool isStatusValid = Enum.TryParse(searchStatus, true, out status);

				if (isStatusValid)
				{
					tasks = tasks.Where(t => t.Status == status);
				}
			}

			if (!string.IsNullOrWhiteSpace(searchTerm))
			{
				string searchTermInLowercase = searchTerm.ToLower();

				tasks = tasks.Where(t => t.Title.ToLower().Contains(searchTermInLowercase) || t.Description.ToLower().Contains(searchTermInLowercase));
			}

			tasks = dateSorting switch
			{
				DateSorting.Newest => tasks.OrderByDescending(t => t.CreatedOn),
				DateSorting.Oldest => tasks.OrderBy(t => t.CreatedOn),
				_ => tasks.OrderBy(t => t.CreatedOn)
			};

			var taskModels = await tasks.Skip((currentPage - 1) * tasksPerPage)
				.Take(tasksPerPage)
				.Select(t => new TaskViewModel()
				{
					Id = t.Id,
					Title = t.Title,
					Description = t.Description,
					CreatedOn = t.CreatedOn,
					Status = t.Status,
					Creator = t.CreatorId
				})
				.ToListAsync();

			int totalTasksCount = await tasks.CountAsync();

			return new TaskQueryServiceModel()
			{
				TotalTasksCount = totalTasksCount,
				Tasks = taskModels
			};
		}

		public IEnumerable<string> GetAllStatusesAsString() => new List<string>()
		{
			Status.NotStarted.ToString(),
			Status.InProgress.ToString(),
			Status.Finished.ToString()
		};

		public IEnumerable<int> GetAllStatusesAsInt() => new List<int>()
		{
			(int)Status.NotStarted,
			(int)Status.InProgress,
			(int)Status.Finished
		};



		public bool DoesStatusExist(int statusId)
		{
			var statuses = GetAllStatusesAsInt();

			return statuses.Any(s => s == statusId);
		}

		public async System.Threading.Tasks.Task CreateTaskAsync(TaskAddFormModel taskModel, string userId)
		{
			var task = new Task()
			{
				Title = taskModel.Title,
				Description = taskModel.Description,
				CreatedOn = DateTime.UtcNow,
				CreatorId = userId,
				Status = (Status)taskModel.StatusId
			};

			await _repository.AddAsync<Task>(task);
			await _repository.SaveChangesAsync();
		}

		public async Task<bool> DoesTaskExistAsync(int taskId) => await _repository.AllReadOnly<Task>()
				.AnyAsync(w => w.Id == taskId);

		public async Task<TaskEditFormModel?> GetTaskEditFormModelByIdAsync(int taskId)
		{
			var task = await _repository.AllReadOnly<Task>()
				.Where(t => t.Id == taskId)
				.Select(t => new TaskEditFormModel()
				{
					Title = t.Title,
					Description = t.Description,
					StatusId = (int)t.Status,
					CreatorId = t.CreatorId
				})
				.FirstOrDefaultAsync();

			if (task != null)
			{
				task.Statuses = GetAllStatusesAsInt();
			}

			return task;
		}

		public async System.Threading.Tasks.Task EditTaskAsync(int taskId, TaskEditFormModel taskModel)
		{
			var task = await _repository.GetByIdAsync<Task>(taskId);

			if (task != null)
			{
				task.Title = taskModel.Title;
				task.Description = taskModel.Description;
				task.Status = (Status)taskModel.StatusId;
			}

			await _repository.SaveChangesAsync();
		}

		public async Task<TaskViewModel?> GetTaskViewModelByIdAsync(int taskId) =>
			await _repository.AllReadOnly<Task>()
			.Where(w => w.Id == taskId)
			.Select(w => new TaskViewModel()
			{
				Id = w.Id,
				Title = w.Title,
				Description = w.Description,
				CreatedOn = w.CreatedOn,
				Status = w.Status,
				Creator = w.CreatorId
			})
			.FirstOrDefaultAsync();

		public async System.Threading.Tasks.Task DeleteTaskAsync(int taskId)
		{
			var taskToDelete = await _repository.GetByIdAsync<Task>(taskId);

			if (taskToDelete != null)
			{
				_repository.Delete<Task>(taskToDelete);
				await _repository.SaveChangesAsync();
			}
		}
	}
}
