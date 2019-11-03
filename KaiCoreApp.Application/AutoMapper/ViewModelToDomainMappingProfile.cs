using AutoMapper;
using KaiCoreApp.Application.ViewModels.Product;
using KaiCoreApp.Application.ViewModels.System;
using KaiCoreApp.Data.Entities;
using System;

namespace KaiCoreApp.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProductCategoryViewModel, ProductCategory>()
                .ConstructUsing(c => new ProductCategory(c.Name, c.Description, c.ParentId, c.HomeOrder,
                c.Images, c.HomeFlag, c.SortOrder, c.Status, c.SeoPageTitle, c.SeoAlias, c.SeoKeywords, c.SeoDescription));

            CreateMap<ProductViewModel, Product>()
                .ConstructUsing(c => new Product(c.Name, c.CategoryID, c.Image, c.Price, c.OriginalPrice, c.PromotionPrice,
                c.Description, c.Content, c.HomeFlag, c.HotFlag, c.Tags, c.Unit, c.Status, c.SeoPageTitle,
                c.SeoAlias, c.SeoKeywords, c.SeoDescription));

            CreateMap<AppUserViewModel, AppUser>()
                .ConstructUsing(c => new AppUser(c.Id.GetValueOrDefault(Guid.Empty), c.FullName, c.Avatar, c.Email,
                                                    c.PhoneNumber, c.Status, c.UserName));
        }
    }
}