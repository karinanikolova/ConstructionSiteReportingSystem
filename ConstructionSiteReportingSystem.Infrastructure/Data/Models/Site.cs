using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities;

namespace ConstructionSiteReportingSystem.Infrastructure.Data.Models
{
    [Comment("Construction site")]
    public class Site : SoftDelete
    {
        [Key]
        [Comment("Construction site identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Investment project/Construction site name identifier")]
        public int ProjectSiteNameId { get; set; }

        [ForeignKey(nameof(ProjectSiteNameId))]
        public ProjectSiteName ProjectSiteName { get; set; } = null!;

        [Required]
        [Comment("Construction site finish date")]
        public DateTime FinishDate { get; set; }

        public ICollection<SiteStage> SitesStages { get; set; } = new List<SiteStage>();
    }
}
