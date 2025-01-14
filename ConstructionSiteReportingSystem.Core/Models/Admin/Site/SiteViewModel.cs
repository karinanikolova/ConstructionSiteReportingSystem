namespace ConstructionSiteReportingSystem.Core.Models.Admin.Site
{
	public class SiteViewModel
    {
		public int Id { get; set; }

		public string Name { get; set; } = string.Empty;

        public DateTime FinishDate { get; set; }

        public int WorksCount { get; set; }

        public IEnumerable<int> WorkIds { get; set; } = new List<int>();

        public int UsersPostedCount { get; set; }
    }
}