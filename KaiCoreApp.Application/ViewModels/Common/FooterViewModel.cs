using System.ComponentModel.DataAnnotations;

namespace KaiCoreApp.Application.ViewModels.Common
{
    public class FooterViewModel
    {
        public string Id { get; set; }

        [Required]
        public string Content { get; set; }
    }
}