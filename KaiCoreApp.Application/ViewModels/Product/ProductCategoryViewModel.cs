using KaiCoreApp.Data.Enums;
using System;
using System.Collections.Generic;

namespace KaiCoreApp.Application.ViewModels.Product
{
    public class ProductCategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
        public int? HomeOrder { get; set; }

        public string Images { get; set; }
        public bool HomeFlag { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DateModified { get; set; }
        public int SortOrder { get; set; }
        public Status Status { get; set; }
        public string SeoPageTitle { get; set; }

        public string SeoAlias { get; set; }

        public string SeoKeywords { get; set; }

        public string SeoDescription { get; set; }

        public ICollection<ProductViewModel> Products { get; set; }
    }
}