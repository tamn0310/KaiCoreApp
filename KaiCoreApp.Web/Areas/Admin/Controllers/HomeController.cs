using KaiCoreApp.Application.Dapper.Interface;
using KaiCoreApp.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KaiCoreApp.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IReportService _reportService;

        public HomeController(IReportService reportService)
        {
            this._reportService = reportService;
        }

        public IActionResult Index()
        {
            var email = User.GetSpecificClaim("Email");
            return View();
        }

        public async Task<IActionResult> GetRevenue(string fromDate, string toDate)
        {
            return new OkObjectResult(await _reportService.GetReports(fromDate, toDate));
        }
    }
}