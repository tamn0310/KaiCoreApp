using KaiCoreApp.Application.ViewModels.Product;
using System;
using System.Collections.Generic;

namespace KaiCoreApp.Application.Interfaces
{
    public interface IProductService : IDisposable
    {
        List<ProductViewModel> GetAll();
    }
}