using ConstructionSiteReportingSystem.Core.Contracts;
using ConstructionSiteReportingSystem.Core.Models.Home;
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

        public async Task<IEnumerable<IndexViewModel>> ProjectsForPreviewAsync()
		{
			return await _repository.AllReadOnly<ProjectSiteName>()
				.OrderByDescending(psn => psn.Id)
				.Take(3)
				.Select(psn => new IndexViewModel()
				{
					Id = psn.Id,
					Name = psn.Name,
					ImageUrl = psn.ImageUrl
				})
				.ToListAsync();
		}
	}
}
