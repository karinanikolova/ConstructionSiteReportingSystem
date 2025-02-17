using ConstructionSiteReportingSystem.Core.Common;
using ConstructionSiteReportingSystem.Core.Extensions;
using ConstructionSiteReportingSystem.Core.Models.Admin.Site;
using ConstructionSiteReportingSystem.Core.Models.Site;
using ConstructionSiteReportingSystem.Core.Services.Contracts;
using ConstructionSiteReportingSystem.Infrastructure.Data.Models;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities.Contracts;
using ConstructionSiteReportingSystem.Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using static ConstructionSiteReportingSystem.Core.Constants.ValidationConstants;
using Stage = ConstructionSiteReportingSystem.Infrastructure.Data.Models.Stage;
using Task = System.Threading.Tasks.Task;

namespace ConstructionSiteReportingSystem.Core.Services
{
	public class ConstructionSiteService : IConstructionSiteService
	{
		private readonly IRepository _repository;

		public ConstructionSiteService(IRepository repository)
		{
			_repository = repository;
		}

		public async Task<IEnumerable<SiteInfoViewModel>> GetAllSiteInfoViewModelsAsync()
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

		public async Task<SiteQueryServiceModel?> GetSiteAsync(int siteId, string? stage = null, string? searchDate = null, DateSorting dateSorting = DateSorting.Newest, int currentPage = 1, int worksPerPage = 1)
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
				var works = _repository.AllReadOnly<Work>()
				.Where(w => w.SiteId == siteId);

				var allStages = await GetAllStagesNamesAsync();


				if (!string.IsNullOrWhiteSpace(stage) && allStages.Any(s => s == stage))
				{
					works = _repository.AllReadOnly<Work>()
						.Where(w => w.SiteId == siteId && w.Stage.Name == stage);
				}

				DateTime date;
				bool isDateValid = DateTime.TryParseExact(searchDate, DateTimePreferredFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

				if (isDateValid)
				{
					works = works
						.Where(w => w.CarryOutDate.Year == date.Year
						&& w.CarryOutDate.Month == date.Month
						&& w.CarryOutDate.Day == date.Day);
				}

				var workModels = await works
				.Select(w => new WorkViewModel()
				{
					Id = w.Id,
					WorkName = w.WorkType.Name,
					Description = w.Description,
					CarryOutDate = w.CarryOutDate,
					Stage = w.Stage.Name,
					Contractor = w.Contractor.Name,
					Quantity = w.Quantity,
					Unit = w.Unit.Type,
					CostPerUnit = w.CostPerUnit,
					TotalCost = w.TotalCost,
					Creator = w.Creator.UserName
				})
				.ToListAsync();

				workModels = dateSorting switch
				{
					DateSorting.Newest => workModels.OrderByDescending(w => w.CarryOutDate).ToList(),
					DateSorting.Oldest => workModels.OrderBy(w => w.CarryOutDate).ToList(),
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
				.Where(c => c.IsApproved == true)
				.Select(s => s.Name)
				.Distinct()
				.ToListAsync();
		}

		public async Task<string> GetSiteInformationAsync(int siteId)
		{
			var site = await _repository
				.AllReadOnly<Site>()
				.Where(s => s.Id == siteId)
				.Select(s => new SiteInfoViewModel()
				{
					Id = s.Id,
					Name = s.Name,
					FinishDate = DateTimeConverter.ConvertDateToString(s.FinishDate)
				})
				.FirstAsync();

			return site.GetInformation();
		}

		public async Task CreateSiteAsync(SiteAddFormModel siteModel, DateTime finishDate)
		{
			var site = new Site()
			{
				Name = siteModel.Name,
				FinishDate = finishDate,
				ImageUrl = siteModel.ImageUrl
			};

			await _repository.AddAsync<Site>(site);
			await _repository.SaveChangesAsync();
		}

		public async Task DeleteSiteAsync(int siteId)
		{
			var siteToDelete = await _repository.GetByIdAsync<Site>(siteId);

			if (siteToDelete != null)
			{
				_repository.Delete<Site>(siteToDelete);
				await _repository.SaveChangesAsync();
			}
		}

		public async Task<bool> DoesSiteExistAsync(int siteId) => await _repository.AllReadOnly<Site>()
				.AnyAsync(s => s.Id == siteId);

		public async Task<bool> DoesSiteNameExistAsync(string siteName) => await _repository.AllReadOnly<Site>()
				.AnyAsync(s => s.Name == siteName);

		public async Task<SiteViewModel?> GetSiteViewModelByIdAsync(int siteId) => await _repository.AllReadOnly<Site>()
			.Where(s => s.Id == siteId)
			.Select(s => new SiteViewModel()
			{
				Id = s.Id,
				Name = s.Name,
				FinishDate = s.FinishDate,
				WorksCount = s.Works.Select(w => w.Id).Count(),
				WorkIds = s.Works.Select(w => w.Id),
				UsersPostedCount = s.Works.Select(c => c.CreatorId).Distinct().Count()
			})
			.FirstOrDefaultAsync();

		public async Task<IEnumerable<int>?> GetSiteWorkIdsAsync(int siteId)
		{
			var siteWorks = _repository.AllReadOnly<Work>()
				.Where(w => w.SiteId == siteId);

			if (!siteWorks.Any())
			{
				return null;
			}

			return await siteWorks
				.Select(w => w.Id)
				.ToArrayAsync();
		}
	}
}