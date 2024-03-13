using ConstructionSiteReportingSystem.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionSiteReportingSystem.Controllers
{
	public class ConstructionSiteController : BaseController
	{
		private readonly ILogger<ConstructionSiteController> _logger;
		private readonly IConstructionSiteService _constructionSiteService;

		public ConstructionSiteController(ILogger<ConstructionSiteController> logger, IConstructionSiteService constructionSiteService)
		{
			_logger = logger;
			_constructionSiteService = constructionSiteService;
		}

		[HttpGet]
		public async Task<IActionResult> ConstructionSite(int id)
		{
			var site = await _constructionSiteService.GetSiteAsync(id);

			if (site == null)
			{
				return BadRequest();
			}

			return View(site);
		}
	}
}
