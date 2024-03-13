using ConstructionSiteReportingSystem.Core.Contracts;
using ConstructionSiteReportingSystem.Core.Models.Project;
using ConstructionSiteReportingSystem.Infrastructure.Data.Models;
using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ConstructionSiteReportingSystem.Core.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IRepository _repository;

        public ProjectService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProjectInfoViewModel>> AllProjectsAsync()
        {
            return await _repository
                .AllReadOnly<ProjectSiteName>()
                .Select(psn => new ProjectInfoViewModel()
                {
                    Id = psn.Id,
                    Name = psn.Name
                })
                .OrderByDescending(psn => psn.Id)
                .ToListAsync();
        }
    }
}
