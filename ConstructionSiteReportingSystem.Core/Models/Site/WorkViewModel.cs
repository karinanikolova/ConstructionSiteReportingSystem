namespace ConstructionSiteReportingSystem.Core.Models.Site
{
    public class WorkViewModel
    {
        public int Id { get; set; }

        public string WorkName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public DateTime CarryOutDate { get; set; }

        public string Contractor { get; set; } = string.Empty;

        public double Quantity { get; set; }

        public string Unit { get; set; } = string.Empty;

        public decimal CostPerUnit { get; set; }

        public decimal TotalCost { get; set; }

        public string CreatorId { get; set; } = string.Empty;
    }
}
