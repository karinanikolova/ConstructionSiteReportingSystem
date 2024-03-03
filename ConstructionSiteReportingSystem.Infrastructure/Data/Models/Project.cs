using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities;

namespace ConstructionSiteReportingSystem.Infrastructure.Data.Models
{
    [Comment("Investment project")]
    public class Project : SoftDelete
    {
        [Key]
        [Comment("Investment project identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Investment project/Construction site information identifier")]
        public int ProjectSiteInfoId { get; set; }

        [ForeignKey(nameof(ProjectSiteInfoId))]
        public ProjectSiteInfo ProjectSiteInfo { get; set; } = null!;

        public ICollection<WorkByProject> WorksByProjects { get; set; } = new List<WorkByProject>();
    }
}
