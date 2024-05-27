using ConstructionSiteReportingSystem.Core.Models.Site;
using ConstructionSiteReportingSystem.Core.Models.Task;
using ConstructionSiteReportingSystem.Infrastructure.Enums;

namespace ConstructionSiteReportingSystem.Core.Contracts
{
	public interface ITaskService
	{
		Task<TaskQueryServiceModel> GetAllTasksAsync(string? searchStatus = null, string? searchTerm = null, DateSorting dateSorting = DateSorting.Newest, int currentPage = 1, int tasksPerPage = 1);
	}
}
