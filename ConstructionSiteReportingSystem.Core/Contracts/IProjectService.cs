using ConstructionSiteReportingSystem.Core.Models.Home;

namespace ConstructionSiteReportingSystem.Core.Contracts
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectIndexViewModel>> ProjectsForPreviewAsync();
    }
}
