using ConstructionSiteReportingSystem.Core.Models.Task;
using ConstructionSiteReportingSystem.Infrastructure.Enums;

namespace ConstructionSiteReportingSystem.Core.Services.Contracts
{
	public interface ITaskService
    {
        Task<TaskQueryServiceModel> GetAllUserTasksAsync(string userId, string? searchStatus = null, string? searchTerm = null, DateSorting dateSorting = DateSorting.Newest, int currentPage = 1, int tasksPerPage = 1);

        IEnumerable<string> GetAllStatusesAsString();
    }
}
