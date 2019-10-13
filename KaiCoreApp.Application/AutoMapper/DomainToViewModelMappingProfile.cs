using AutoMapper;
using KaiCoreApp.Application.ViewModels.Product;
using KaiCoreApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaiCoreApp.Application.AutoMapper
{
   public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ProductCategory, ProductCategoryViewModel>();
        }
    }
}
