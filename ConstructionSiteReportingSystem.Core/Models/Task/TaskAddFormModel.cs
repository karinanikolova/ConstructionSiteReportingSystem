using System.ComponentModel.DataAnnotations;
using static ConstructionSiteReportingSystem.Core.Constants.MessageConstants;
using static ConstructionSiteReportingSystem.Infrastructure.Constants.DataConstants.Task;

namespace ConstructionSiteReportingSystem.Core.Models.Task
{
	public class TaskAddFormModel
	{
		[Required(ErrorMessage = RequiredFieldMessage)]
		[StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = TaskFieldLengthMessage)]
		public string Title { get; set; } = string.Empty;

		[Required(ErrorMessage = RequiredFieldMessage)]
		[StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = TaskFieldLengthMessage)]
		public string Description { get; set; } = string.Empty;

		[Display(Name = "Status")]
		public int StatusId { get; set; }

		public IEnumerable<int> Statuses { get; set; } = new List<int>();
	}
}
