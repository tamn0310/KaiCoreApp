using KaiCoreApp.Application.ViewModels.Product;
using KaiCoreApp.Utilities.Dtos;
using System;
using System.Collections.Generic;

namespace KaiCoreApp.Application.Interfaces
{
    public interface IProductService : IDisposable
    {
        List<ProductViewModel> GetAll();

        PagedResult<ProductViewModel> GetAllPaging(int? categoryId, string search, int page, int pageSize);
    }
}