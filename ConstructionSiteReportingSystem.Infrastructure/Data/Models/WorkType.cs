﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities;
using static ConstructionSiteReportingSystem.Infrastructure.Constants.DataConstants.WorkType;

namespace ConstructionSiteReportingSystem.Infrastructure.Data.Models
{
    [Comment("Construction and assembly work type")]
    public class WorkType : SoftDelete
    {
        [Key]
        [Comment("Construction and assembly work type identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Construction and assembly work type name")]
        public string Name { get; set; } = string.Empty;

		[Required]
		[Comment("Is construction and assembly work type approved by the administrator")]
		public bool IsApproved { get; set; }

		public ICollection<Work> Works { get; set; } = new List<Work>();
    }
}