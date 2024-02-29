﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities;
using static ConstructionSiteReportingSystem.Infrastructure.Constants.DataConstants.Stage;

namespace ConstructionSiteReportingSystem.Infrastructure.Data.Models
{
    [Comment("Construction stage")]
    public class Stage : SoftDelete
    {
        [Key]
        [Comment("Construction stage identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Construction stage name")]
        public string Name { get; set; } = string.Empty;

        public ICollection<SiteStage> SitesStages { get; set; } = new List<SiteStage>();

        public ICollection<Work> Works { get; set; } = new List<Work>();
    }
}
