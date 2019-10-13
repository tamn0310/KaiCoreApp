using System.Collections.Generic;
using System.Linq;
using KaiCoreApp.Data.Entities;
using KaiCoreApp.Data.IRepositories;

namespace KaiCoreApp.EF.Repositories
{
    public class ProductCategoryRepository : Repository<ProductCategory, int>, IProductCategoryRepository
    {
        private AppDbContext _context;

        public ProductCategoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public List<ProductCategory> GetByAlias(string alias)
        {
            return _context.ProductCategories.Where(x => x.SeoAlias == alias).ToList();
        }
    }
}