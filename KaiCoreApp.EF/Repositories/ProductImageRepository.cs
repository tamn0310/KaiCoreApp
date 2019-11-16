using KaiCoreApp.Data.Entities;
using KaiCoreApp.Data.IRepositories;

namespace KaiCoreApp.EF.Repositories
{
    public class ProductImageRepository : Repository<ProductImage, int>, IProductImageRepository
    {
        public ProductImageRepository(AppDbContext context) : base(context)
        {
        }
    }
}