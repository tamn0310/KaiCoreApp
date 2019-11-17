using Microsoft.AspNetCore.Mvc;

namespace KaiCoreApp.Web.Controllers
{
    public class ContactController : Controller
    {
        [Route("lien-he.html")]
        public IActionResult Index()
        {
            return View();
        }
    }
}