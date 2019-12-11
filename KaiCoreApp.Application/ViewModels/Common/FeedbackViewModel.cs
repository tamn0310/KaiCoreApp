using KaiCoreApp.Data.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace KaiCoreApp.Application.ViewModels.Common
{
    public class FeedbackViewModel
    {
        public int Id { get; set; }

        [StringLength(250)]
        [Required]
        public string Name { set; get; }

        [StringLength(250)]
        public string Email { set; get; }

        [StringLength(500)]
        public string Message { set; get; }

        public Status Status { set; get; }
        public DateTime CreatedDate { set; get; }
        public DateTime DateModified { set; get; }
    }
}