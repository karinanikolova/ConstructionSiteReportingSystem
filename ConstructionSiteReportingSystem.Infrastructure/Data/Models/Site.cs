using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static ConstructionSiteReportingSystem.Infrastructure.Constants.DataConstants.Site;

namespace ConstructionSiteReportingSystem.Infrastructure.Data.Models
{
	[Comment("Construction site")]
    public class Site : SoftDelete
    {
        [Key]
        [Comment("Construction site identifier")]
        public int Id { get; set; }

        [Required]
		[MaxLength(NameMaxLength)]
		[Comment("Construction site name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Comment("Construction site finish date")]
        public DateTime FinishDate { get; set; }

		[Required]
		[Comment("Construction site image URL")]
		public string ImageUrl { get; set; } = string.Empty;

		public ICollection<Work> Works { get; set; } = new List<Work>();
    }
}
