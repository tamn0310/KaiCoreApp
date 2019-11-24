using KaiCoreApp.Application.Interfaces;
using KaiCoreApp.Web.Models.ProductViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace KaiCoreApp.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;
        private IConfiguration _configuration;

        public ProductController(IProductService productService, IProductCategoryService productCategoryService, IConfiguration configuration)
        {
            this._productService = productService;
            this._productCategoryService = productCategoryService;
            this._configuration = configuration;
        }

        [Route("products.html")]
        public IActionResult Index(string search, string sortBy, int? limit, int page = 1)
        {
            var product = new ListViewModel();
            ViewData["BodyClass"] = "category-page";
            if (limit == null)
            {
                limit = _configuration.GetValue<int>("Limit");
            }
            product.Limit = limit;
            product.SortType = sortBy;
            product.Data = _productService.GetAll(sortBy, string.Empty, page, limit.Value);

            return View(product);
        }

        [Route("{alias}-c.{id}.html")]
        public IActionResult Catalog(int id, string search, int? limit, string sortBy, int page = 1)
        {
            var catalog = new CatalogViewModel();
            ViewData["BodyClass"] = "category-page";
            if (limit == null)
            {
                limit = _configuration.GetValue<int>("Limit");
            }
            catalog.Limit = limit;
            catalog.SortType = sortBy;
            catalog.Data = _productService.GetAllPaging(id, sortBy, string.Empty, page, limit.Value);
            catalog.Category = _productCategoryService.GetById(id);
            return View(catalog);
        }

        [Route("{alias}-p.{id}.html", Name = "ProductDetail")]
        public IActionResult Details(int id)
        {
            ViewData["BodyCss"] = "single-product-page";
            var model = new DetailViewModel();
            model.Product = _productService.GetById(id);
            model.Category = _productCategoryService.GetById(model.Product.CategoryID);
            model.RelatedProducts = _productService.GetRelatedProducts(id, 9);
            model.UpsellProducts = _productService.GetUpsellProducts(6);
            model.ProductImages = _productService.GetImages(id);
            model.Tags = _productService.GetProductTags(id);
            return View(model);
        }
    }
}