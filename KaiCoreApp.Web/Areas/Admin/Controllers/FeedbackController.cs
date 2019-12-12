using KaiCoreApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KaiCoreApp.Web.Areas.Admin.Controllers
{
    public class FeedbackController : BaseController
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            this._feedbackService = feedbackService;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region

        [HttpGet]
        public IActionResult GetAllPaging(string search, int page, int pageSize)
        {
            var model = _feedbackService.GetAllPaging(search, page, pageSize);
            return new ObjectResult(model);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var model = _feedbackService.GetById(id);
            return new ObjectResult(model);
        }

        #endregion
    }
}