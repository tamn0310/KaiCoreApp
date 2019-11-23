using System.ComponentModel.DataAnnotations;

namespace KaiCoreApp.Web.Models.AccountViewModel
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}