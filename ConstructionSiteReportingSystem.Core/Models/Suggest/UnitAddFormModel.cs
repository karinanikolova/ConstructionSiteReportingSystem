using System.ComponentModel.DataAnnotations;
using static ConstructionSiteReportingSystem.Core.Constants.MessageConstants;
using static ConstructionSiteReportingSystem.Infrastructure.Constants.DataConstants.Unit;

namespace ConstructionSiteReportingSystem.Core.Models.Suggest
{
	public class UnitAddFormModel
	{
		[Required(ErrorMessage = RequiredFieldMessage)]
		[StringLength(TypeMaxLength, MinimumLength = TypeMinLength, ErrorMessage = FieldLengthMessage)]
		public string Type { get; set; } = string.Empty;
	}
}