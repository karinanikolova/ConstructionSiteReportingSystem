using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities;

namespace ConstructionSiteReportingSystem.Infrastructure.Data.Models
{
    [Comment("Construction site and construction/assembly work mapping table")]
    public class SiteWork : SoftDelete
    {
        [Required]
        [Comment("Construction site identifier")]
        public int SiteId { get; set; }

        [ForeignKey(nameof(SiteId))]
        public Site Site { get; set; } = null!;

        [Required]
        [Comment("Construction and assembly work identifier")]
        public int WorkId { get; set; }

        [ForeignKey(nameof(WorkId))]
        public Work Work { get; set; } = null!;
	}
}
