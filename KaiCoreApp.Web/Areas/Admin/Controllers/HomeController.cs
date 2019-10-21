using KaiCoreApp.Web.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace KaiCoreApp.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            var email = User.GetSpecificClaim("Email");
            return View();
        }
    }
}