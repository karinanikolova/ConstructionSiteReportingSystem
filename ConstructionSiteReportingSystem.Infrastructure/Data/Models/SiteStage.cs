using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities;

namespace ConstructionSiteReportingSystem.Infrastructure.Data.Models
{
    [Comment("Construction site and construction stage mapping table")]
    public class SiteStage : SoftDelete
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
    }
}
