using KaiCoreApp.Data.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace KaiCoreApp.Application.ViewModels.Product
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Required]
        public int CategoryID { get; set; }

        public decimal Price { get; set; }
        public decimal? PromotionPrice { get; set; }
        public decimal OriginalPrice { get; set; }

        [StringLength(256)]
        public string Description { get; set; }

        public string Content { get; set; }
        public bool? HomeFlag { get; set; }
        public bool HotFlag { get; set; }
        public int? ViewCount { get; set; }

        public string Image { get; set; }

        public string Tags { get; set; }

        public string Unit { get; set; }

        public Status Status { get; set; }
        public string SeoPageTitle { get; set; }

        public string SeoAlias { get; set; }

        public string SeoKeywords { get; set; }

        public string SeoDescription { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime DateModified { get; set; }

        public ProductCategoryViewModel ProductCategory { get; set; }
    }
}