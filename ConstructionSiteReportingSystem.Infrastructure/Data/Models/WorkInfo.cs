using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities;
using static ConstructionSiteReportingSystem.Infrastructure.Constants.DataConstants.WorkInfo;

namespace ConstructionSiteReportingSystem.Infrastructure.Data.Models
{
    [Comment("Construction and assembly work additional information")]
    public class WorkInfo : SoftDelete
    {
        [Key]
        [Comment("Construction and assembly work additional information identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Construction and assembly work name")]
        public string Name { get; set; } = string.Empty;

        public ICollection<Work> Works { get; set; } = new List<Work>();

        public ICollection<WorkByProject> WorksByProjects { get; set; } = new List<WorkByProject>();
    }
}
