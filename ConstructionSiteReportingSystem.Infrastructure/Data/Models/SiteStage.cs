using ConstructionSiteReportingSystem.Infrastructure.Data.Models.Contracts;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructionSiteReportingSystem.Infrastructure.Data.Models
{
    [Comment("Construction site and construction stage mapping table")]
    public class SiteStage : ISoftDelete
    {
        [Required]
        [Comment("Construction site identifier")]
        public int SiteId { get; set; }

        [ForeignKey(nameof(SiteId))]
        public Site Site { get; set; } = null!;

        [Required]
        [Comment("Construction stage identifier")]
        public int StageId { get; set; }

        [ForeignKey(nameof(StageId))]
        public Stage Stage { get; set; } = null!;

        [Required]
        [Comment("Construction site and construction stage deleted state")]
        public bool IsDeleted { get; private set; } = false;

        [Comment("Construction site and construction stage deletion point in time")]
        public DateTimeOffset? DeletedAt { get; private set; } = null;

        public void UndoDelete()
        {
            IsDeleted = false;
            DeletedAt = null;
        }
    }
}
