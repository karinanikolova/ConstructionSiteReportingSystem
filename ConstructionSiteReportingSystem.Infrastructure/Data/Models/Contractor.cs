using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static ConstructionSiteReportingSystem.Infrastructure.Constants.DataConstants.Contractor;

namespace ConstructionSiteReportingSystem.Infrastructure.Data.Models
{
    [Comment("Construction contractor")]
    public class Contractor : SoftDelete
    {
        [Key]
        [Comment("Construction contractor identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Construction contractor name")]
        public string Name { get; set; } = string.Empty;

        public ICollection<Work> Works { get; set; } = new List<Work>();
    }
}
