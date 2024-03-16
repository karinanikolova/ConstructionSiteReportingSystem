namespace ConstructionSiteReportingSystem.Core.Models.Site
{
    public class SiteViewModel
    {
        public string Name { get; set; } = string.Empty;

        public DateTime FinishDate { get; set; }

        public IEnumerable<StageViewModel> Stages { get; set; } = new List<StageViewModel>();
    }
}
