using Microsoft.AspNetCore.Mvc;

namespace ConstructionSiteReportingSystem.Components
{
    public class NavigationBarComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult<IViewComponentResult>(View());
        }
    }
}
