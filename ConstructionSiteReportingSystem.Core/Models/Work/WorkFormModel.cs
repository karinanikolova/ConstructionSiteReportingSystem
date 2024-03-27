using System.ComponentModel.DataAnnotations;
using static ConstructionSiteReportingSystem.Core.Constants.MessageConstants;
using static ConstructionSiteReportingSystem.Infrastructure.Constants.DataConstants.Work;

namespace ConstructionSiteReportingSystem.Core.Models.Work
{
	public class WorkFormModel
	{
		[Display(Name = "Construction site")]
		public int SiteId { get; set; }

		[Display(Name = "Type")]
		public int WorkTypeId { get; set; }

		[StringLength(DescriptionMaxLength, ErrorMessage = NotRequiredFieldMessage)]
		public string? Description { get; set; }

		[Required(ErrorMessage = DateMessage)]
		[Display(Name = "Carry out date")]
		public string CarryOutDate { get; set; } = string.Empty;

		[Display(Name = "Stage")]
		public int StageId { get; set; }

		[Display(Name = "Contractor")]
		public int ContractorId { get; set; }

		[Required(ErrorMessage = RequiredFieldMessage)]
		[Range(QuantityMinValue, QuantityMaxValue, ConvertValueInInvariantCulture = true,
			ErrorMessage = QuantityMessage)]
		public double Quantity { get; set; }

		[Display(Name = "Unit")]
		public int UnitId { get; set; }

		[Display(Name = "Cost per unit")]
		[Required(ErrorMessage = RequiredFieldMessage)]
		[Range((double)CostPerUnitMinValue, (double)CostPerUnitMaxValue, ConvertValueInInvariantCulture = true,
			ErrorMessage = CostPerUnitMessage)]
		public decimal CostPerUnit { get; set; }

		[Required]
		[Display(Name = "Total cost")]
		public decimal TotalCost { get; set; }

		public IEnumerable<WorkTypeServiceModel> WorkTypes { get; set; } = new List<WorkTypeServiceModel>();

		public IEnumerable<StageServiceModel> Stages { get; set; } = new List<StageServiceModel>();

		public IEnumerable<ContractorServiceModel> Contractors { get; set; } = new List<ContractorServiceModel>();

		public IEnumerable<UnitServiceModel> Units { get; set; } = new List<UnitServiceModel>();

		public IEnumerable<SiteServiceModel> Sites { get; set; } = new List<SiteServiceModel>();
	}
}
