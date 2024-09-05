using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities;
using static ConstructionSiteReportingSystem.Infrastructure.Constants.DataConstants.Stage;

namespace ConstructionSiteReportingSystem.Infrastructure.Data.Models
{
    [Comment("Construction stage")]
    public class Stage : SoftDelete
    {
        [Key]
        [Comment("Construction stage identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Construction stage name")]
        public string Name { get; set; } = string.Empty;

		[Required]
		[Comment("Is construction stage approved by the administrator")]
		public bool IsApproved { get; set; }

		public ICollection<Work> Works { get; set; } = new List<Work>();
    }
}