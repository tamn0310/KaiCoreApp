using KaiCoreApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KaiCoreApp.Data.Entities
{
    [Table("Tags")]
    public class Tag 
    {
        [Key]
        [Column(TypeName ="varchar(50)")]
        public string Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MaxLength(50)]
        [Required]
        public string Type { get; set; }
    }
}
