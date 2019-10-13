using KaiCoreApp.Data.Enums;
using KaiCoreApp.Data.Interfaces;
using KaiCoreApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KaiCoreApp.Data.Entities
{
    [Table("ProductCategories")]
    public class ProductCategory : DomainEntity<int>, IHasSeoMetaData, ISwitchable, ISortable, IDateTracking
    {
        public ProductCategory()
        {
            Products = new List<Product>();
        }

        [MaxLength(256)]
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
        public int? HomeOrder { get; set; }

        [StringLength(256)]
        public string Image { get; set; }
        public bool HomeFlag { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DateModified { get; set; }
        public int SortOrder { get; set; }
        public Status Status { get; set; }
        public string SeoPageTitle { get; set; }

        [StringLength(256)]
        [Column(TypeName ="varchar")]
        public string SeoAlias { get; set; }

        [StringLength(256)]
        public string SeoKeywords { get; set; }

        [StringLength(256)]
        public string SeoDescription { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}