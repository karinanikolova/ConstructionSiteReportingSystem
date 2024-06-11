using ConstructionSiteReportingSystem.Core.Extensions.Contracts;

namespace ConstructionSiteReportingSystem.Core.Models.Site
{
    public class SiteInfoViewModel : ISiteModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string FinishDate { get; set; } = string.Empty;
    }
}