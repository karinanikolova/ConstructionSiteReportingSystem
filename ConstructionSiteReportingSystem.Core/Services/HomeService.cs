using ConstructionSiteReportingSystem.Core.Models.Home;
using ConstructionSiteReportingSystem.Core.Services.Contracts;
using ConstructionSiteReportingSystem.Infrastructure.Data.Models;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ConstructionSiteReportingSystem.Core.Services
{
    public class HomeService : IHomeService
	{
		private readonly IRepository _repository;

        public HomeService(IRepository repository)
        {
			_repository = repository;
        }

        public async Task<IEnumerable<IndexViewModel>> SitesForPreviewAsync()
		{
			return await _repository.AllReadOnly<Site>()
				.Take(3)
				.Select(s => new IndexViewModel()
				{
					Id = s.Id,
					Name = s.Name,
					ImageUrl = s.ImageUrl
				})
				.ToListAsync();
		}
	}
}
