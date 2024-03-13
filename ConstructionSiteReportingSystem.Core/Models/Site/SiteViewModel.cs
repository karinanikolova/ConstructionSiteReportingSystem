namespace ConstructionSiteReportingSystem.Core.Models.Site
{
    public class SiteViewModel
    {
        public DateTime FinishDate { get; set; }

        public IEnumerable<StageViewModel> Stages { get; set; } = new List<StageViewModel>();
    }
}
