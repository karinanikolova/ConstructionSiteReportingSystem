using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using ConstructionSiteReportingSystem.Infrastructure.Data.Models.Contracts;
using static ConstructionSiteReportingSystem.Infrastructure.Constants.DataConstants.Stage;

namespace ConstructionSiteReportingSystem.Infrastructure.Data.Models
{
    [Comment("Construction stage")]
    public class Stage : ISoftDelete
    {
        [Key]
        [Comment("Construction stage identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxValue)]
        [Comment("Construction stage type")]
        public string Name { get; set; } = string.Empty;

        public ICollection<SiteStage> SitesStages { get; set; } = new List<SiteStage>();

        public ICollection<Work> Works { get; set; } = new List<Work>();

        [Required]
        [Comment("Construction stage deleted state")]
        public bool IsDeleted { get; private set; } = false;

        [Comment("Construction stage deletion point in time")]
        public DateTimeOffset? DeletedAt { get; private set; } = null;

        public void UndoDelete()
        {
            IsDeleted = false;
            DeletedAt = null;
        }
    }
}
