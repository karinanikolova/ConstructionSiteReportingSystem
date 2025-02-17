using ConstructionSiteReportingSystem.Core.Models.Admin.Site;
using ConstructionSiteReportingSystem.Core.Services.Contracts;
using ConstructionSiteReportingSystem.Infrastructure.Constants;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Security.Claims;
using System.Text.RegularExpressions;
using static ConstructionSiteReportingSystem.Core.Constants.ValidationConstants;

namespace ConstructionSiteReportingSystem.Areas.Admin.Controllers
{
	public class ConstructionSiteController : AdminBaseController
	{
		private readonly ILogger<ConstructionSiteController> _logger;
		private readonly IConstructionSiteService _constructionSiteService;
		private readonly IWorkService _workService;

		public ConstructionSiteController(ILogger<ConstructionSiteController> logger, IConstructionSiteService constructionSiteService, IWorkService workService)
		{
			_logger = logger;
			_constructionSiteService = constructionSiteService;
			_workService = workService;
		}

		[HttpGet]
		public async Task<IActionResult> AddSite()
		{
			return View(new SiteAddFormModel());
		}

		[HttpPost]
		public async Task<IActionResult> AddSite(SiteAddFormModel siteModel)
		{
			if (string.IsNullOrWhiteSpace(siteModel.Name))
			{
				ModelState.AddModelError(nameof(siteModel.Name), "A construction site name cannot contain only white space characters");

				return View(siteModel);
			}

			siteModel.Name = siteModel.Name.Trim();

			Regex siteNameRegex = new Regex(DataConstants.Site.NameMatchRegex);

			if (!siteNameRegex.IsMatch(siteModel.Name))
			{
				ModelState.AddModelError(nameof(siteModel.Name), "The construction site name suggestion is not valid");

				return View(siteModel);
			}

			if (await _constructionSiteService.DoesSiteNameExistAsync(siteModel.Name) == true)
			{
				ModelState.AddModelError(nameof(siteModel.Name), "A construction site with the given name already exists");
			}

			DateTime date;
			bool isDateValid = DateTime.TryParseExact(siteModel.FinishDate, DateTimePreferredFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

			if (!isDateValid || date.Year < DateTime.UtcNow.Year)
			{
				ModelState.AddModelError(nameof(siteModel.FinishDate), "The specified date is not valid");
			}

			if (!ModelState.IsValid)
			{
				return View(siteModel);
			}

			await _constructionSiteService.CreateSiteAsync(siteModel, date);

			return RedirectToAction("All", "ConstructionSite", new { area = "" });
		}

		[HttpGet]
		public async Task<IActionResult> DeleteSite(int id)
		{
			if (await _constructionSiteService.DoesSiteExistAsync(id) == false)
			{
				return BadRequest();
			}

			var site = await _constructionSiteService.GetSiteViewModelByIdAsync(id);

			if (User.IsAdmin() == false)
			{
				return Unauthorized();
			}

			return View(site);
		}

		[HttpPost]
		public async Task<IActionResult> DeleteSite(string workIds, SiteViewModel siteModel)
		{
			if (await _constructionSiteService.DoesSiteExistAsync(siteModel.Id) == false)
			{
				return BadRequest();
			}

			if (User.IsAdmin() == false)
			{
				return Unauthorized();
			}

			var siteWorkIds = await _constructionSiteService.GetSiteWorkIdsAsync(siteModel.Id);

			await _constructionSiteService.DeleteSiteAsync(siteModel.Id);

			if (workIds != "0" && siteWorkIds != null)
			{
				var workIdsArr = workIds.Split(", ", StringSplitOptions.RemoveEmptyEntries);

				foreach (var workId in workIdsArr.Distinct())
				{
					int id = int.Parse(workId);

					if (siteWorkIds.Contains(id))
					{
						await _workService.DeleteWorkAsync(id);
					}
				}
			}

			return RedirectToAction("All", "ConstructionSite", new { area = "" });
		}
	}
}