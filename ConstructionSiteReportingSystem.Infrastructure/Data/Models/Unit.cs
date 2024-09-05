using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities;
using static ConstructionSiteReportingSystem.Infrastructure.Constants.DataConstants.Unit;

namespace ConstructionSiteReportingSystem.Infrastructure.Data.Models
{
    [Comment("Measurement unit")]
    public class Unit : SoftDelete
    {
        [Key]
        [Comment("Measurement unit identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(TypeMaxLength)]
        [Comment("Measurement unit type")]
        public string Type { get; set; } = string.Empty;

		[Required]
		[Comment("Is measurement unit approved by the administrator")]
		public bool IsApproved { get; set; }

		public ICollection<Work> Works { get; set; } = new List<Work>();
    }
}