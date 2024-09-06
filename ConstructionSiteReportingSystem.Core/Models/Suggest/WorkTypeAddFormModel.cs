using System.ComponentModel.DataAnnotations;
using static ConstructionSiteReportingSystem.Core.Constants.MessageConstants;
using static ConstructionSiteReportingSystem.Infrastructure.Constants.DataConstants.WorkType;

namespace ConstructionSiteReportingSystem.Core.Models.Suggest
{
	public class WorkTypeAddFormModel
	{
		[Required(ErrorMessage = RequiredFieldMessage)]
		[StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = FieldLengthMessage)]
		public string Name { get; set; } = string.Empty;
	}
}