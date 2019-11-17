namespace KaiCoreApp.Application.ViewModels.Product
{
    public class BillDetailViewModel
    {
        public int Id { get; set; }

        public int BillId { set; get; }

        public int ProductId { set; get; }

        public int Quantity { set; get; }

        public decimal Price { set; get; }

        public virtual BillViewModel Bill { set; get; }

        public virtual ProductViewModel Product { set; get; }
    }
}