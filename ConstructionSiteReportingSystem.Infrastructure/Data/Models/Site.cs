using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ConstructionSiteReportingSystem.Infrastructure.Data.Models.Contracts;

namespace ConstructionSiteReportingSystem.Infrastructure.Data.Models
{
    [Comment("Construction site")]
    public class Site : ISoftDelete
    {
        [Key]
        [Comment("Construction site identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Investment project/Construction site information identifier")]
        public int ProjectSiteInfoId { get; set; }

        [ForeignKey(nameof(ProjectSiteInfoId))]
        public ProjectSiteInfo ProjectSiteInfo { get; set; } = null!;

        [Required]
        [Comment("Construction site finish date")]
        public DateTime FinishDate { get; set; }

        public ICollection<SiteStage> SitesStages { get; set; } = new List<SiteStage>();

        [Required]
        [Comment("Site deleted state")]
        public bool IsDeleted { get; private set; } = false;

        [Comment("Site deletion point in time")]
        public DateTimeOffset? DeletedAt { get; private set; } = null;

        public void UndoDelete()
        {
            IsDeleted = false;
            DeletedAt = null;
        }
    }
}
