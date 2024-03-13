using ConstructionSiteReportingSystem.Core.Models.Project;

namespace ConstructionSiteReportingSystem.Core.Contracts
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectInfoViewModel>> AllProjectsAsync();
    }
}
