using System.ComponentModel.DataAnnotations;
using static ConstructionSiteReportingSystem.Core.Constants.MessageConstants;
using static ConstructionSiteReportingSystem.Infrastructure.Constants.DataConstants.Stage;

namespace ConstructionSiteReportingSystem.Core.Models.Suggest
{
	public class StageAddFormModel
	{
		[Required(ErrorMessage = RequiredFieldMessage)]
		[StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = FieldLengthMessage)]
		public string Name { get; set; } = string.Empty;
	}
}