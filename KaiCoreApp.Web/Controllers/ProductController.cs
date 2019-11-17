using Microsoft.AspNetCore.Mvc;

namespace KaiCoreApp.Web.Controllers
{
    public class ProductController : Controller
    {
        [Route("san-pham.html")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("{alias}-c.{id}.html")]
        public IActionResult Catalog(int id, string search, int? limit, int page = 1, string sortBy="")
        {
            return View();
        }
    }
}