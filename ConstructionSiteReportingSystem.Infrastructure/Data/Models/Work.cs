using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities;
using static ConstructionSiteReportingSystem.Infrastructure.Constants.DataConstants.Work;

namespace ConstructionSiteReportingSystem.Infrastructure.Data.Models
{
    [Comment("Construction and assembly work")]
    public class Work : SoftDelete
    {
        [Key]
        [Comment("Construction and assembly work identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Construction and assembly work type identifier")]
        public int WorkTypeId { get; set; }

        [ForeignKey(nameof(WorkTypeId))]
        public WorkType WorkType { get; set; } = null!;

        [MaxLength(DescriptionMaxLength)]
        [Comment("Construction and assembly work description")]
        public string? Description { get; set; }

        [Required]
        [Comment("Construction and assembly work carry out date and time")]
        public DateTime CarryOutDate { get; set; }

        [Required]
        [Comment("Construction and assembly work stage identifier")]
        public int StageId { get; set; }

        [ForeignKey(nameof(StageId))]
        public Stage Stage { get; set; } = null!;

        [Required]
        [Comment("Construction and assembly work contractor identifier")]
        public int ContractorId { get; set; }

        [ForeignKey(nameof(ContractorId))]
        public Contractor Contractor { get; set; } = null!;

        [Required]
        [Comment("Construction and assembly work quantity")]
        public double Quantity { get; set; }

        [Required]
        [Comment("Construction and assembly work measurement unit identifier")]
        public int UnitId { get; set; }

        [ForeignKey(nameof(UnitId))]
        public Unit Unit { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Comment("Construction and assembly work cost per measurement unit")]
        public decimal CostPerUnit { get; set; }

        [Required]
        [Column(TypeName = "decimal(36,2)")]
        [Comment("Construction and assembly work total cost")]
        public decimal TotalCost => Convert.ToDecimal(Quantity) * CostPerUnit;

        [Required]
        [Comment("Construction and assembly work creator identifier")]
        public string CreatorId { get; set; } = string.Empty;

        [ForeignKey(nameof(CreatorId))]
        public IdentityUser Creator { get; set; } = null!;

        [Required]
        [Comment("Boolean value that determines if the current construction and assembly work is included in the total quantity report")]
        public bool IsIncluded { get; set; }
    }
}
