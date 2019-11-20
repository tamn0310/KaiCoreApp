using KaiCoreApp.Application.ViewModels.Blog;
using KaiCoreApp.Application.ViewModels.Common;
using KaiCoreApp.Application.ViewModels.Product;
using System.Collections.Generic;

namespace KaiCoreApp.Web.Models
{
    public class HomeViewModel
    {
        public List<BlogViewModel> LastestBlogs { get; set; }
        public List<SlideViewModel> HomeSlides { get; set; }
        public List<ProductViewModel> HotProducts { get; set; }
        public List<ProductViewModel> TopSellProducts { get; set; }
        public List<ProductCategoryViewModel> HomeCategories { get; set; }

        public string Title { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }
    }
}