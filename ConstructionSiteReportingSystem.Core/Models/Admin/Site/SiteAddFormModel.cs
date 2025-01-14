using System.ComponentModel.DataAnnotations;
using static ConstructionSiteReportingSystem.Infrastructure.Constants.DataConstants.Site;
using static ConstructionSiteReportingSystem.Core.Constants.MessageConstants;

namespace ConstructionSiteReportingSystem.Core.Models.Admin.Site
{
    public class SiteAddFormModel
    {
        [Required(ErrorMessage = RequiredFieldMessage)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = FieldLengthMessage)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = DateMessage)]
        [Display(Name = "Finish date")]
        public string FinishDate { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredFieldMessage)]
		[Display(Name = "Image URL")]
        [Url]
		public string ImageUrl { get; set; } = string.Empty;
    }
}