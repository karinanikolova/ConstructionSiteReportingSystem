using ConstructionSiteReportingSystem.Infrastructure.Enums;
using System.ComponentModel.DataAnnotations;

namespace ConstructionSiteReportingSystem.Core.Models.Task
{
	public class AllTasksQueryModel
	{
		public const int TasksPerPage = 3;

		public string Status { get; init; } = null!;

		[Display(Name = "Search by text")]
		public string? SearchTerm { get; init; }

		public DateSorting Sorting { get; init; }

		public int CurrentPage { get; init; } = 1;

		public int TotalTasksCount { get; set; }

		public IEnumerable<string> Statuses { get; set; } = new List<string>();

		public IEnumerable<TaskViewModel> Tasks { get; set; } = new List<TaskViewModel>();
	}
}
