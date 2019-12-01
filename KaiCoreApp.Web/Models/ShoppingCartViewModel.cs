using KaiCoreApp.Application.ViewModels.Product;

namespace KaiCoreApp.Web.Models
{
    public class ShoppingCartViewModel
    {
        public ProductViewModel Product { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}