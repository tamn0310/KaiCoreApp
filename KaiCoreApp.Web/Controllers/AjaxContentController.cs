using Microsoft.AspNetCore.Mvc;

namespace KaiCoreApp.Web.Controllers
{
    public class AjaxContentController : Controller
    {
        public IActionResult HeaderCart()
        {
            return ViewComponent("HeaderCart");
        }
    }
}