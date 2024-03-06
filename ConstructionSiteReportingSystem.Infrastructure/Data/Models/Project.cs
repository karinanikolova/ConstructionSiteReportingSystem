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
        [Comment("Investment project/Construction site name identifier")]
        public int ProjectSiteNameId { get; set; }

        [ForeignKey(nameof(ProjectSiteNameId))]
        public ProjectSiteName ProjectSiteName { get; set; } = null!;

        public ICollection<WorkByProject> WorksByProjects { get; set; } = new List<WorkByProject>();
    }
}
