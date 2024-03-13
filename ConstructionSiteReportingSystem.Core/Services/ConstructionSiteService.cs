using ConstructionSiteReportingSystem.Core.Contracts;
using ConstructionSiteReportingSystem.Core.Models.Project;
using ConstructionSiteReportingSystem.Core.Models.Site;
using ConstructionSiteReportingSystem.Infrastructure.Data.Models;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionSiteReportingSystem.Core.Services
{
	public class ConstructionSiteService : IConstructionSiteService
	{
		private readonly IRepository _repository;

		public ConstructionSiteService(IRepository repository)
		{
			_repository = repository;
		}

		public async Task<SiteViewModel> GetSiteAsync(int projectSiteNameId)
		{
			return await _repository.AllReadOnly<Site>()
				.Where(s => s.ProjectSiteNameId == projectSiteNameId)
				.Select(s => new SiteViewModel()
				{
					FinishDate = s.FinishDate,
					Stages = s.SitesStages
					.Where(ss => ss.SiteId == s.Id)
					.Select (stage => new StageViewModel()
					{
						Name = stage.Stage.Name
					})
					.ToList()
				})
				.FirstOrDefaultAsync();
		}
	}
}
