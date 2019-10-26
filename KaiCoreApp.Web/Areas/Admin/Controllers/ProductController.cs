using KaiCoreApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KaiCoreApp.Web.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region AJAX API
        [HttpGet]
        public IActionResult GetAll()
        {
            var model = _productService.GetAll();
            return new ObjectResult(model);
        }

        [HttpGet]
        public IActionResult GetAllPaging(int? categoryId, string search,int page, int pageSize)
        {
            var model = _productService.GetAllPaging(categoryId,search,page,pageSize);
            return new ObjectResult(model);
        }
        #endregion
    }
}