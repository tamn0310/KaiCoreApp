using KaiCoreApp.Application.ViewModels.Product;
using KaiCoreApp.Utilities.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace KaiCoreApp.Web.Models.ProductViewModels
{
    /// <summary>
    /// Lấy tất cả sản phẩm: phân trang, sắp xếp
    /// </summary>
    public class ListViewModel
    {
        public PagedResult<ProductViewModel> Data { get; set; }

        public ProductViewModel Product { set; get; }

        public string SortType { set; get; }

        public int? Limit { set; get; }

        public List<SelectListItem> SortTypes { get; } = new List<SelectListItem>
        {
            new SelectListItem(){Value = "lastest", Text = "Mới nhất"},
            new SelectListItem(){Value = "price_dec", Text = "Giá từ cao xuống thấp"},
            new SelectListItem(){Value = "price_asc", Text = "Giá từ thấp tới cao"},
            new SelectListItem(){Value = "name_asc", Text = "Tên sản phẩm(A-Z)"},
            new SelectListItem(){Value = "name_dec", Text = "Tên sản phẩm(Z-A)"},
        };

        public List<SelectListItem> Limits { get; } = new List<SelectListItem>
        {
             new SelectListItem(){Value = "8",Text = "8"},
            new SelectListItem(){Value = "12",Text = "12"},
            new SelectListItem(){Value = "24",Text = "24"},
            new SelectListItem(){Value = "48",Text = "48"},
        };
    }
}