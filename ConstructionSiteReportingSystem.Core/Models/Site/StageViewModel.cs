namespace ConstructionSiteReportingSystem.Core.Models.Site
{
    public class StageViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public ICollection<WorkViewModel> Works { get; set; } = new List<WorkViewModel>();
    }
}
