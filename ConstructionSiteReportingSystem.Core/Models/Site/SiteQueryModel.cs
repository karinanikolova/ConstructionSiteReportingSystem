﻿using ConstructionSiteReportingSystem.Core.Extensions.Contracts;
using ConstructionSiteReportingSystem.Infrastructure.Enums;
using System.ComponentModel.DataAnnotations;

namespace ConstructionSiteReportingSystem.Core.Models.Site
{
	public class SiteQueryModel : ISiteModel
    {
        public const int WorksPerPage = 5;

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Stage { get; init; } = null!;

        [Display(Name = "Search by date")]
        public string? SearchDate { get; init; }

        public DateSorting Sorting { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalWorksCount { get; set; }

        public DateTime ConstructionFinishDate { get; set; }

        public IEnumerable<string> Stages { get; set; } = new List<string>();

		public IEnumerable<WorkViewModel> Works { get; set; } = new List<WorkViewModel>();

		public string FinishDate { get; set; } = string.Empty;
	}
}