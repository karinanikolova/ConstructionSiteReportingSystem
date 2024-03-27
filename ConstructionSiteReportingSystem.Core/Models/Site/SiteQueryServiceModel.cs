namespace ConstructionSiteReportingSystem.Core.Models.Site
{
    public class SiteQueryServiceModel
    {
        public string SiteName { get; set; } = string.Empty;

        public DateTime ConstructionFinishDate { get; set; }

        public int TotalWorksCount { get; set; }

		public IEnumerable<WorkViewModel> Works { get; set; } = new List<WorkViewModel>();
	}
}
