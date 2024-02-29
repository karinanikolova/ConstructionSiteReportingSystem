using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities;
using static ConstructionSiteReportingSystem.Infrastructure.Constants.DataConstants.ProjectSiteInfo;

namespace ConstructionSiteReportingSystem.Infrastructure.Data.Models
{
    [Comment("Investment project/Construction site information")]
    public class ProjectSiteInfo : SoftDelete
    {
        [Key]
        [Comment("Investment project/Construction site information identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Investment project/Construction site name")]
        public string Name { get; set; } = string.Empty;

        public Site Site { get; set; } = null!;
        public Project Project { get; set;} = null!;
    }
}
