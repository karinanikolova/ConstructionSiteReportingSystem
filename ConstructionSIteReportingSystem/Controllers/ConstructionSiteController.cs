using ConstructionSiteReportingSystem.Core.Models.Site;
using ConstructionSiteReportingSystem.Core.Services.Contracts;
using ConstructionSiteReportingSystem.Core.Extensions;
using Microsoft.AspNetCore.Mvc;
using ConstructionSiteReportingSystem.Core.Common;

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
		public async Task<IActionResult> All()
		{
			var models = await _constructionSiteService.GetAllSiteInfoViewModelsAsync();

			return View(models);
		}

		[HttpGet]
		public async Task<IActionResult> Site(int id, string information, [FromQuery] SiteQueryModel model)
		{
			var site = await _constructionSiteService.GetSiteAsync(
				id,
				model.Stage,
				model.SearchDate,
				model.Sorting,
				model.CurrentPage,
				SiteQueryModel.WorksPerPage);

			if (site == null)
			{
				return BadRequest();
			}

			model.TotalWorksCount = site.TotalWorksCount;
			model.Works = site.Works;
			model.Id = id;
			model.Name = site.SiteName;
			model.ConstructionFinishDate = site.ConstructionFinishDate;
			model.Stages = await _constructionSiteService.GetAllStagesNamesAsync();
			model.FinishDate = DateTimeConverter.ConvertDateToString(site.ConstructionFinishDate);

			if (information != model.GetInformation())
			{
				return BadRequest();
			}

			return View(model);
		}
	}
}