﻿using ConstructionSiteReportingSystem.Core.Models.Site;
using ConstructionSiteReportingSystem.Infrastructure.Enums;

namespace ConstructionSiteReportingSystem.Core.Contracts
{
	public interface IConstructionSiteService
	{
		Task<SiteQueryServiceModel> GetSiteAsync(int projectSiteNameId, string? stage = null, string? searchDate = null, DateSorting dateSorting = DateSorting.Newest, int currentPage = 1, int worksPerPage = 1);

		Task<IEnumerable<string>> GetAllStagesNamesAsync();
	}
}
