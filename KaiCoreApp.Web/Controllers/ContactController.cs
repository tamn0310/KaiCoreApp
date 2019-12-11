using KaiCoreApp.Application.Interfaces;
using KaiCoreApp.Utilities.Constants;
using KaiCoreApp.Web.Models;
using KaiCoreApp.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace KaiCoreApp.Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IFeedbackService _feedbackService;
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration _configuration;
        private readonly IViewRenderService _viewRenderService;

        public ContactController(IContactService contactService, IFeedbackService feedbackService, IEmailSender emailSender,
            IConfiguration configuration, IViewRenderService viewRenderService)
        {
            this._contactService = contactService;
            this._feedbackService = feedbackService;
            this._emailSender = emailSender;
            this._configuration = configuration;
            this._viewRenderService = viewRenderService;
        }

        [Route("contact.html")]
        [HttpGet]
        public IActionResult Index()
        {
            var contact = _contactService.GetById(CommonConstants.DefaultContactId);
            var model = new ContactPageViewModel { Contact = contact };
            return View(model);
        }

        [Route("contact.html")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Index(ContactPageViewModel model)
        {
            if (ModelState.IsValid)
            {
                _feedbackService.Add(model.Feedback);
                _feedbackService.SaveChanges();
                var content = await _viewRenderService.RenderToStringAsync("Contact/_ContactMail", model.Feedback);
                await _emailSender.SendEmailAsync(_configuration["MailSettings:AdminMail"], "Có phản hồi mới", content);
                ViewData["Success"] = true;
            }

            model.Contact = _contactService.GetById(CommonConstants.DefaultContactId);

            return View("Index", model);
        }
    }
}