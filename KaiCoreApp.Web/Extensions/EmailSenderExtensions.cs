using KaiCoreApp.Web.Services;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace KaiCoreApp.Web.Extensions
{
    public static class EmailSenderExtensions
    {
        /// <summary>
        /// Send mail for user register
        /// </summary>
        /// <param name="emailSender"></param>
        /// <param name="email"></param>
        /// <param name="link"></param>
        /// <returns></returns>
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, "Confirm your email",
                $"Please confirm your account by clicking this link: <a href='{HtmlEncoder.Default.Encode(link)}'>link</a>");
        }
    }
}