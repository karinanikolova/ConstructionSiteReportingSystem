using ConstructionSiteReportingSystem.Core.Contracts;
using ConstructionSiteReportingSystem.Core.Models.Site;
using ConstructionSiteReportingSystem.Infrastructure.Data.Models;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities.Contracts;
using ConstructionSiteReportingSystem.Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using static ConstructionSiteReportingSystem.Core.Constants.ValidationConstants;
using static ConstructionSiteReportingSystem.Infrastructure.Constants.DataConstants;
using Work = ConstructionSiteReportingSystem.Infrastructure.Data.Models.Work;

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
                //Fix stages input -> should give all stages to the stage list
                var siteStagesWithWorks = _repository.AllReadOnly<SiteStage>()
                .Where(ss => ss.Site.ProjectSiteNameId == projectSiteNameId);

                if (!string.IsNullOrWhiteSpace(stage))
                {
                    siteStagesWithWorks = _repository.AllReadOnly<SiteStage>()
                .Where(ss => ss.Site.ProjectSiteNameId == projectSiteNameId && ss.Stage.Name == stage);
                }

                DateTime date;
                bool isDateValid = DateTime.TryParseExact(searchDate, DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

                if (isDateValid)
                {
                    //Fix filtering by specific date
                    siteStagesWithWorks = siteStagesWithWorks
                        .Where(sw => sw.Stage.Works.Any(w => w.CarryOutDate == date));

                    if (stage == null)
                    {
                        var stageModel = siteStagesWithWorks
                            .Select(sw => new StageViewModel()
                            {
                                Id = sw.Stage.Id,
                                Name = sw.Stage.Name,
                                Works = sw.Stage.Works
                                .Where(w => w.CarryOutDate == date)
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

                        site.StagesWithWorks = stageModels;
                    }
                }
                else
                {
                    var stagesIds = siteStagesWithWorks.Select(s => s.StageId);

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

                    foreach (var stageId in stagesIds)
                    {
                        if (dateSorting == DateSorting.Newest)
                        {
                            stageModels.Where(s => s.Id == stageId)
                                .Select(s => s.Works.OrderBy(w => w.CarryOutDate).ToList());
                        }
                        else
                        {
                            stageModels.Where(s => s.Id == stageId)
                                .Select(s => s.Works.OrderByDescending(w => w.CarryOutDate).ToList());
                        }
                    }

                    site.StagesWithWorks = stageModels;
                }

                site.TotalWorksCount = site.StagesWithWorks.Select(sw => sw.Works.Count).Sum();
            }

            return site;
        }
    }
}
