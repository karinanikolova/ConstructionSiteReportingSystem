using ConstructionSiteReportingSystem.Core.Models.Work;
using ConstructionSiteReportingSystem.Core.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionSiteReportingSystem.Areas.Admin.Controllers
{
	public class ForReviewController : AdminBaseController
	{
		private readonly ILogger<ForReviewController> _logger;
		private readonly IForReviewService _forReviewService;

		public ForReviewController(ILogger<ForReviewController> logger, IForReviewService forReviewService)
		{
			_logger = logger;
			_forReviewService = forReviewService;
		}

		[HttpGet]
		public async Task<IActionResult> ApproveContractors()
		{
			var contractorModels = await _forReviewService.GetContractorsForReviewAsync();

			if (contractorModels == null)
			{
				return BadRequest();
			}

			return View(contractorModels);
		}

		[HttpPost]
		public async Task<IActionResult> ApproveContractor(int id)
		{
			throw new NotImplementedException();
		}

		[HttpPost]
		public async Task<IActionResult> RemoveContractor(int id)
		{
			throw new NotImplementedException();
		}
	}
}