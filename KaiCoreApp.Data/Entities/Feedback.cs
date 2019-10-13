using KaiCoreApp.Data.Enums;
using KaiCoreApp.Data.Interfaces;
using KaiCoreApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KaiCoreApp.Data.Entities
{
    [Table("Feedbacks")]
    public class Feedback : DomainEntity<int>, ISwitchable, IDateTracking
    {

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
