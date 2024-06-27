using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities;
using ConstructionSiteReportingSystem.Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ConstructionSiteReportingSystem.Infrastructure.Constants.DataConstants.Task;

namespace ConstructionSiteReportingSystem.Infrastructure.Data.Models
{
	[Comment("User tasks")]
    public class Task : SoftDelete
    {
        [Key]
        [Comment("Task identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        [Comment("Task title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        [Comment("Task description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Task creation date")]
        public DateTime CreatedOn { get; set; }

        [Required]
        [Comment("Task creator identifier")]
        public string CreatorId { get; set; } = null!;

        [ForeignKey(nameof(CreatorId))]
        public ApplicationUser Creator { get; set; } = null!;

        [Required]
        [Comment("Task's current status")]
        public Status Status {  get; set; }
    }
}
