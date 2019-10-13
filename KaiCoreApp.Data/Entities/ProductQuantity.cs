using KaiCoreApp.Infrastructure.SharedKernel;
using System.ComponentModel.DataAnnotations.Schema;

namespace KaiCoreApp.Data.Entities
{
    [Table("ProductQuantities")]
    public class ProductQuantity : DomainEntity<int>
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}