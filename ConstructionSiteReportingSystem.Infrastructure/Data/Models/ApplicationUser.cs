using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static ConstructionSiteReportingSystem.Infrastructure.Constants.DataConstants.ApplicationUser;

namespace ConstructionSiteReportingSystem.Infrastructure.Data.Models
{
	public class ApplicationUser : IdentityUser
	{
		[Required]
		[MaxLength(FirstNameMaxLength)]
		[PersonalData]
		public string FirstName { get; set; } = string.Empty;

		[Required]
		[MaxLength(MiddleNameMaxLength)]
        [PersonalData]
        public string MiddleName { get; set; } = string.Empty;

		[Required]
		[MaxLength(LastNameMaxLength)]
        [PersonalData]
        public string LastName { get; set; } = string.Empty;
	}
}
