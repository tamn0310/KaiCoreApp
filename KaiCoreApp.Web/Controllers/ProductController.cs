﻿using KaiCoreApp.Application.Interfaces;
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
        public IActionResult Index()
        {
            return View();
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
            return View();
        }
    }
}