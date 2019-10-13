using KaiCoreApp.Data.Entities;
using KaiCoreApp.Infrastructure.Interfaces;
using System.Collections.Generic;

namespace KaiCoreApp.Data.IRepositories
{
    public interface IProductCategoryRepository : IRepository<ProductCategory, int>
    {
        List<ProductCategory> GetByAlias(string alias);
    }
}