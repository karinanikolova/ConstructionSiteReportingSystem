﻿using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructionSiteReportingSystem.Infrastructure.Data.Models
{
    [Comment("Construction and assembly work according to investment project")]
    public class WorkByProject : SoftDelete
    {
        [Key]
        [Comment("Construction and assembly work according to investment project identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Construction and assembly work type identifier according to investment project")]
        public int WorkTypeId { get; set; }

        [ForeignKey(nameof(WorkTypeId))]
        public WorkType WorkType{ get; set; } = null!;

        [Required]
        [Comment("Construction and assembly work according to investment project measurement unit identifier")]
        public int UnitId { get; set; }

        [ForeignKey(nameof(UnitId))]
        public Unit Unit { get; set; } = null!;

        [Required]
        [Comment("Construction and assembly work according to investment project total quantity")]
        public double TotalQuantity { get; set; }

        [Required]
        [Comment("Construction and assembly work investment project identifier")]
        public int ProjectId { get; set; }

        [ForeignKey(nameof(ProjectId))]
        public Project Project { get; set; } = null!;
    }
}
