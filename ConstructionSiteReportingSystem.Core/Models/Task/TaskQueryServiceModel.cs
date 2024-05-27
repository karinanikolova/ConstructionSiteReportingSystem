namespace ConstructionSiteReportingSystem.Core.Models.Task
{
	public class TaskQueryServiceModel
	{
		public int TotalTasksCount { get; set; }

		public IEnumerable<TaskViewModel> Tasks { get; set; } = new List<TaskViewModel>();
	}
}
