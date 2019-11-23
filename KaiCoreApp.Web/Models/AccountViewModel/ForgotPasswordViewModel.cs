using System.ComponentModel.DataAnnotations;

namespace KaiCoreApp.Web.Models.AccountViewModel
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}