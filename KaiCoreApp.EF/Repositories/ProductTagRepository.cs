using KaiCoreApp.Data.Entities;
using KaiCoreApp.Data.IRepositories;

namespace KaiCoreApp.EF.Repositories
{
    public class ProductTagRepository : Repository<ProductTag, int>, IProductTagRepository
    {
        public ProductTagRepository(AppDbContext context):base(context)
        {

        }
    }
}