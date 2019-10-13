using KaiCoreApp.Data.Enums;
using KaiCoreApp.Data.Interfaces;
using KaiCoreApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KaiCoreApp.Data.Entities
{
    [Table("Products")]
    public class Product : DomainEntity<int>, ISwitchable, IHasSeoMetaData, IDateTracking
    {
        [StringLength(256)]
        [Required]
        public string Name { get; set; }

        [Required]
        public int CategoryID { get; set; }

        public decimal Price { get; set; }
        public decimal PromotionPrice { get; set; }
        public decimal OriginalPrice { get; set; }

        [StringLength(256)]
        public string Description { get; set; }

        public string Height { get; set; }
        public string Weigth { get; set; }
        public string Material { get; set; }
        public string Content { get; set; }
        public bool? HomeFlag { get; set; }
        public bool HotFlag { get; set; }
        public int? ViewCount { get; set; }

        [StringLength(256)]
        public string Tags { get; set; }

        public string Unit { get; set; }

        public Status Status { get; set; }
        public int SortOrderId { get; set; }
        public string SeoPageTitle { get; set; }

        [StringLength(256)]
        public string SeoAlias { get; set; }

        [StringLength(256)]
        public string SeoKeywords { get; set; }

        [StringLength(256)]
        public string SeoDescription { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime DateModified { get; set; }

        [ForeignKey("CategoryID")]
        public virtual ProductCategory ProductCategory { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}