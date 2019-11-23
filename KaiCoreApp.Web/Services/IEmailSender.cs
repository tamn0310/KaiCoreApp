using System.Threading.Tasks;

namespace KaiCoreApp.Web.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}