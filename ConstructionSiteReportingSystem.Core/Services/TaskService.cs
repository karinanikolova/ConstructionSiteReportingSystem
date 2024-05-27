using ConstructionSiteReportingSystem.Core.Contracts;
using ConstructionSiteReportingSystem.Core.Models.Task;
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

		public async Task<TaskQueryServiceModel> GetAllTasksAsync(string? searchStatus = null, string? searchTerm = null, DateSorting dateSorting = DateSorting.Newest, int currentPage = 1, int tasksPerPage = 1)
		{
			var tasks = _repository.AllReadOnly<Task>();

			if (!string.IsNullOrWhiteSpace(searchStatus) && (searchStatus == Status.NotStarted.ToString() || searchStatus == Status.InProgress.ToString()) || searchStatus == Status.Finished.ToString())
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
					Status = t.Status
				})
				.ToListAsync();

			int totalTasksCount = await tasks.CountAsync();

			return new TaskQueryServiceModel()
			{
				TotalTasksCount = totalTasksCount,
				Tasks = taskModels
			};
		}
	}
}
