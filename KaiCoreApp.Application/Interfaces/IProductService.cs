﻿using KaiCoreApp.Application.ViewModels.Common;
using KaiCoreApp.Application.ViewModels.Product;
using KaiCoreApp.Utilities.Dtos;
using System;
using System.Collections.Generic;

namespace KaiCoreApp.Application.Interfaces
{
    public interface IProductService : IDisposable
    {
        List<ProductViewModel> GetAll();

        PagedResult<ProductViewModel> GetAllPaging(int? categoryId, string sort, string search, int page, int pageSize);

        PagedResult<ProductViewModel> GetAll(string sort, string search, int page, int limit);

        ProductViewModel Add(ProductViewModel product);

        void Update(ProductViewModel product);

        void Delete(int id);

        ProductViewModel GetById(int id);

        void ImportExcel(string filePath, int categoryId);

        void Save();

        void AddQuantity(int productId, List<ProductQuantityViewModel> productQuantities);

        List<ProductQuantityViewModel> GetQuantities(int productId);

        void AddImages(int productId, string[] images);

        List<ProductImageViewModel> GetImages(int productId);

        void AddWholePrice(int productId, List<WholePriceViewModel> wholePrices);

        List<WholePriceViewModel> GetWholePrices(int productId);

        List<ProductViewModel> GetHotProduct(int top);

        List<ProductViewModel> GetLastest(int top);

        List<ProductViewModel> GetRelatedProducts(int id, int top);

        List<ProductViewModel> GetUpsellProducts(int top);

        List<TagViewModel> GetProductTags(int productId);

        bool CheckAvailability(int productId);
    }
}