using System.ComponentModel.DataAnnotations;
using static ConstructionSiteReportingSystem.Core.Constants.MessageConstants;
using static ConstructionSiteReportingSystem.Infrastructure.Constants.DataConstants.Contractor;

namespace ConstructionSiteReportingSystem.Core.Models.Suggest
{
	public class ContractorAddFormModel
	{
		[Required(ErrorMessage = RequiredFieldMessage)]
		[StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = ContractorFieldLengthMessage)]
		public string Name { get; set; } = string.Empty;
	}
}