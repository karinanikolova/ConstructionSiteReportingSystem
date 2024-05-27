using ConstructionSiteReportingSystem.Infrastructure.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ConstructionSiteReportingSystem.Core.Models.Task
{
	public class TaskViewModel
	{
		public int Id { get; set; }

		public string Title { get; set; } = string.Empty;

		public string Description { get; set; } = string.Empty;

		public DateTime CreatedOn { get; set; }

		public Status Status { get; set; }

		public string Creator { get; set; } = string.Empty;
	}
}
