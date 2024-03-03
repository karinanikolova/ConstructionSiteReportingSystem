using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionSiteReportingSystem.Infrastructure.Data.Models
{
    [Comment("Construction and assembly work according to investment project")]
    public class WorkByProject : SoftDelete
    {
        [Key]
        [Comment("Construction and assembly work according to investment project identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Construction and assembly work according to investment project additional information")]
        public int WorkInfoId { get; set; }

        [ForeignKey(nameof(WorkInfoId))]
        public WorkInfo WorkInfo { get; set; } = null!;

        [Comment("Construction and assembly work according to investment project quantity")]
        public double Quantity { get; set; }

        [Required]
        [Comment("Construction and assembly work according to investment project unit identifier")]
        public int UnitId { get; set; }

        [ForeignKey(nameof(UnitId))]
        public Unit Unit { get; set; } = null!;

        [Required]
        [Comment("Construction and assembly work according to investment project total quantity")]
        public double ToTalQuantity { get; set; }

        public ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}
