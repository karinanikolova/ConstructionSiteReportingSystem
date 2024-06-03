using ConstructionSiteReportingSystem.Core.Models.Task;
using ConstructionSiteReportingSystem.Infrastructure.Enums;

namespace ConstructionSiteReportingSystem.Core.Services.Contracts
{
	public interface ITaskService
    {
        Task<TaskQueryServiceModel> GetAllUserTasksAsync(string userId, string? searchStatus = null, string? searchTerm = null, DateSorting dateSorting = DateSorting.Newest, int currentPage = 1, int tasksPerPage = 1);

        IEnumerable<string> GetAllStatusesAsString();

		IEnumerable<int> GetAllStatusesAsInt();

		Task<TaskEditFormModel?> GetTaskEditFormModelByIdAsync(int taskId);

		Task<TaskViewModel?> GetTaskViewModelByIdAsync(int taskId);

		bool DoesStatusExist(int statusId);

		Task CreateTaskAsync(TaskAddFormModel taskModel, string userId);

		Task<bool> DoesTaskExistAsync(int taskId);

		Task EditTaskAsync(int taskId, TaskEditFormModel taskModel);

		Task DeleteTaskAsync(int taskId);
	}
}
