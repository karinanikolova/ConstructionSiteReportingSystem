using ConstructionSiteReportingSystem.Core.Contracts;
using ConstructionSiteReportingSystem.Core.Models.Home;

namespace ConstructionSiteReportingSystem.Core.Services
{
    public class ProjectService : IProjectService
    {
        public Task<IEnumerable<ProjectIndexViewModel>> ProjectsForPreviewAsync()
        {
            throw new NotImplementedException();
        }
    }
}
