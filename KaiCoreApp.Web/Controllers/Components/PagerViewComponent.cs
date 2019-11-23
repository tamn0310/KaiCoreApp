using KaiCoreApp.Utilities.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KaiCoreApp.Web.Controllers.Components
{
    public class PagerViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(PagedResultBase pagedResultBase)
        {
            return Task.FromResult((IViewComponentResult)View("Default", pagedResultBase));
        }
    }
}