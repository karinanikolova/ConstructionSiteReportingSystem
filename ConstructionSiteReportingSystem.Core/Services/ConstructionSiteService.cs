using ConstructionSiteReportingSystem.Core.Common;
using ConstructionSiteReportingSystem.Core.Contracts;
using ConstructionSiteReportingSystem.Core.Models.Site;
using ConstructionSiteReportingSystem.Infrastructure.Data.Models;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities.Contracts;
using ConstructionSiteReportingSystem.Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using static ConstructionSiteReportingSystem.Core.Constants.ValidationConstants;
using Stage = ConstructionSiteReportingSystem.Infrastructure.Data.Models.Stage;

namespace ConstructionSiteReportingSystem.Core.Services
{
	public class ConstructionSiteService : IConstructionSiteService
	{
		private readonly IRepository _repository;

		public ConstructionSiteService(IRepository repository)
		{
			_repository = repository;
		}

		public async Task<IEnumerable<SiteInfoViewModel>> GetAllSitesAsync()
		{
			return await _repository
				.AllReadOnly<Site>()
				.Select(s => new SiteInfoViewModel()
				{
					Id = s.Id,
					Name = s.Name,
					FinishDate = DateTimeConverter.ConvertDateToString(s.FinishDate)
				})
				.ToListAsync();
		}

		public async Task<SiteQueryServiceModel> GetSiteAsync(int siteId, string? stage = null, string? searchDate = null, DateSorting dateSorting = DateSorting.Newest, int currentPage = 1, int worksPerPage = 1)
		{
			var site = await _repository.AllReadOnly<Site>()
				.Where(s => s.Id == siteId)
				.Select(s => new SiteQueryServiceModel()
				{
					SiteName = s.Name,
					ConstructionFinishDate = s.FinishDate
				})
				.FirstOrDefaultAsync();

			if (site != null)
			{
				var siteWorks = _repository.AllReadOnly<SiteWork>()
				.Where(ss => ss.SiteId == siteId);

				var allStages = await GetAllStagesNamesAsync();


				if (!string.IsNullOrWhiteSpace(stage) && allStages.Any(s => s == stage))
				{
					siteWorks = _repository.AllReadOnly<SiteWork>()
				.Where(ss => ss.SiteId == siteId && ss.Work.Stage.Name == stage);
				}

				DateTime date;
				bool isDateValid = DateTime.TryParseExact(searchDate, DateTimePreferredFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

				if (isDateValid)
				{
					siteWorks = siteWorks
						.Where(sw => sw.Work.CarryOutDate.Year == date.Year
						&& sw.Work.CarryOutDate.Month == date.Month
						&& sw.Work.CarryOutDate.Day == date.Day);
				}

				var workModels = await siteWorks
				.Select(w => new WorkViewModel()
				{
					Id = w.Work.Id,
					WorkName = w.Work.WorkType.Name,
					Description = w.Work.Description,
					CarryOutDate = w.Work.CarryOutDate,
					Stage = w.Work.Stage.Name,
					Contractor = w.Work.Contractor.Name,
					Quantity = w.Work.Quantity,
					Unit = w.Work.Unit.Type,
					CostPerUnit = w.Work.CostPerUnit,
					TotalCost = w.Work.TotalCost,
					Creator = w.Work.Creator.UserName
				})
				.ToListAsync();

				workModels = dateSorting switch
				{
					DateSorting.Newest => workModels.OrderBy(w => w.CarryOutDate).ToList(),
					DateSorting.Oldest => workModels.OrderByDescending(w => w.CarryOutDate).ToList(),
					_ => workModels.OrderBy(w => w.CarryOutDate).ToList()
				};

				site.TotalWorksCount = workModels.Count();
				site.Works = workModels
				.Skip((currentPage - 1) * worksPerPage)
				.Take(worksPerPage)
				.ToList();
			}

			return site;
		}

		public async Task<IEnumerable<string>> GetAllStagesNamesAsync()
		{
			return await _repository.AllReadOnly<Stage>()
				.Select(s => s.Name)
				.Distinct()
				.ToListAsync();
		}
	}
}
