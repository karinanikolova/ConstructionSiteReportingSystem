using ConstructionSiteReportingSystem.Infrastructure.Data.Models.Contracts;
using ConstructionSiteReportingSystem.Infrastructure.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ConstructionSiteReportingSystem.Infrastructure.Constants.DataConstants.Task;

namespace ConstructionSiteReportingSystem.Infrastructure.Data.Models
{
    [Comment("User tasks")]
    public class Task : ISoftDelete
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
        [Comment("Task creator")]
        public int CreatorId { get; set; }

        [ForeignKey(nameof(CreatorId))]
        public IdentityUser Creator { get; set; } = null!;

        [Required]
        [Comment("Task's current status")]
        public Status Status {  get; set; }

        [Required]
        [Comment("Task deleted state")]
        public bool IsDeleted { get; private set; } = false;

        [Comment("Task deletion point in time")]
        public DateTimeOffset? DeletedAt { get; private set; } = null;

        public void UndoDelete()
        {
            IsDeleted = false;
            DeletedAt = null;
        }
    }
}
