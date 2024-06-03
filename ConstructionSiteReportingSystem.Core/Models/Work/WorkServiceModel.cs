namespace ConstructionSiteReportingSystem.Core.Models.Work
{
	public class WorkServiceModel
	{
		public int Id { get; set; }

		public string WorkType { get; set; } = string.Empty;

		public string? Description { get; set; }

		public string CarryOutDate { get; set; } = string.Empty;

		public int SiteId { get; set; }

		public string Stage { get; set; } = string.Empty;

		public string Contractor { get; set; } = string.Empty;

		public double Quantity { get; set; }

		public string Unit { get; set; } = string.Empty;

		public decimal CostPerUnit { get; set; }

		public decimal TotalCost { get; set; }

		public string CreatorId { get; set; } = string.Empty;
	}
}
