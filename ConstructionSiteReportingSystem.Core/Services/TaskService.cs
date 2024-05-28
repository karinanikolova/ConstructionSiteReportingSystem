using ConstructionSiteReportingSystem.Core.Models.Task;
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
					Status = t.Status/*.ToString() == "NotStarted" ? "Not started" : t.Status.ToString() == "InProgress" ? "In progress" : t.Status.ToString()*/,
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

		public IEnumerable<string> GetAllStatusesAsString() =>
			new List<string>()
		{
			Status.NotStarted.ToString(),
			Status.InProgress.ToString(),
			Status.Finished.ToString()
		};

	}
}
