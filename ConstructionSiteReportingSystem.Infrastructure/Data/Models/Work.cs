using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities;

namespace ConstructionSiteReportingSystem.Infrastructure.Data.Models
{
    [Comment("Construction and assembly work")]
    public class Work : SoftDelete
    {
        [Key]
        [Comment("Construction and assembly work identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Construction and assembly work additional information identifier")]
        public int WorkInfoId { get; set; }

        [ForeignKey(nameof(WorkInfoId))]
        public WorkInfo WorkInfo { get; set; } = null!;

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
        [Comment("Construction and assembly work cost per measurement unit")]
        public decimal CostPerUnit { get; set; }

        [Required]
        [Comment("Construction and assembly work total cost")]
        public decimal TotalCost => Convert.ToDecimal(Quantity) * CostPerUnit;

        [Required]
        [Comment("Construction and assembly work creator identifier")]
        public string CreatorId { get; set; } = string.Empty;

        [ForeignKey(nameof(CreatorId))]
        public IdentityUser Creator { get; set; } = null!;
    }
}
