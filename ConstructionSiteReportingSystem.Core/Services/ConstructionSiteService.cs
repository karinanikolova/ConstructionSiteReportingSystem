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

		public async Task<SiteQueryServiceModel> GetSiteAsync(int projectSiteNameId, string? stage = null, string? searchDate = null, DateSorting dateSorting = DateSorting.Newest, int currentPage = 1, int worksPerPage = 1)
		{
			var site = await _repository.AllReadOnly<Site>()
				.Where(s => s.ProjectSiteNameId == projectSiteNameId)
				.Select(s => new SiteQueryServiceModel()
				{
					SiteName = s.ProjectSiteName.Name,
					ConstructionFinishDate = s.FinishDate
				})
				.FirstOrDefaultAsync();

			if (site != null)
			{
				var siteStagesWithWorks = _repository.AllReadOnly<SiteStage>()
				.Where(ss => ss.Site.ProjectSiteNameId == projectSiteNameId);

				var allStages = await GetAllStagesNamesAsync();


				if (!string.IsNullOrWhiteSpace(stage) && allStages.Any(s => s == stage))
				{
					siteStagesWithWorks = _repository.AllReadOnly<SiteStage>()
				.Where(ss => ss.Site.ProjectSiteNameId == projectSiteNameId && ss.Stage.Name == stage);
				}

				DateTime date;
				bool isDateValid = DateTime.TryParseExact(searchDate, DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

				if (isDateValid)
				{
					var stageModel = siteStagesWithWorks
							.Select(sw => new StageViewModel()
							{
								Id = sw.Stage.Id,
								Name = sw.Stage.Name,
								Works = sw.Stage.Works
								.Where(w => w.CarryOutDate.Year == date.Year && w.CarryOutDate.Month == date.Month && w.CarryOutDate.Day == date.Day)
								.Select(w => new WorkViewModel()
								{
									Id = w.Id,
									WorkName = w.WorkType.Name,
									Description = w.Description,
									CarryOutDate = w.CarryOutDate,
									Contractor = w.Contractor.Name,
									Quantity = w.Quantity,
									Unit = w.Unit.Type,
									CostPerUnit = w.CostPerUnit,
									TotalCost = w.TotalCost,
									CreatorId = w.CreatorId
								})
								.ToList()
							})
							.First();

					site.TotalWorksCount = stageModel.Works.Count();

					var worksToTake = stageModel.Works
						.Skip((currentPage - 1) * worksPerPage)
						.Take(worksPerPage)
						.ToList();

					stageModel.Works = worksToTake;

					site.StagesWithWorks.Add(stageModel);
				}
				else
				{
					var stageModels = siteStagesWithWorks
							 .Select(sw => new StageViewModel()
							 {
								 Id = sw.Stage.Id,
								 Name = sw.Stage.Name,
								 Works = sw.Stage.Works
								 .Select(w => new WorkViewModel()
								 {
									 Id = w.Id,
									 WorkName = w.WorkType.Name,
									 Description = w.Description,
									 CarryOutDate = w.CarryOutDate,
									 Contractor = w.Contractor.Name,
									 Quantity = w.Quantity,
									 Unit = w.Unit.Type,
									 CostPerUnit = w.CostPerUnit,
									 TotalCost = w.TotalCost,
									 CreatorId = w.CreatorId
								 })
								 .ToList()
							 })
							 .ToList();

					var works = new List<WorkViewModel>();

					if (stageModels.Count() > 1)
					{
						foreach (var workModels in stageModels.Select(ss => ss.Works))
						{
							foreach (var work in workModels)
							{
								works.Add(work);
							}
						}

						works = dateSorting switch
						{
							DateSorting.Newest => works.OrderBy(w => w.CarryOutDate).ToList(),
							DateSorting.Oldest => works.OrderByDescending(w => w.CarryOutDate).ToList(),
							_ => works.OrderBy(w => w.CarryOutDate).ToList()
						};

						site.AllWorksWithoutStages = works
							.Skip((currentPage - 1) * worksPerPage)
							.Take(worksPerPage);
					}
					else
					{
						foreach (var workModels in stageModels.Select(s => s.Works))
						{
							foreach (var work in workModels)
							{
								works.Add(work);
							}
						}

						works = dateSorting switch
						{
							DateSorting.Newest => works.OrderBy(w => w.CarryOutDate).ToList(),
							DateSorting.Oldest => works.OrderByDescending(w => w.CarryOutDate).ToList(),
							_ => works.OrderBy(w => w.CarryOutDate).ToList()
						};


						stageModels.First().Works = works
							.Skip((currentPage - 1) * worksPerPage)
							.Take(worksPerPage)
							.ToList();

						site.StagesWithWorks = stageModels;
					}

					site.TotalWorksCount = works.Count();
				}
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
