using AutoMapper;
using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.Producer;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.Product;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductCategory;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductImage;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductSpecification;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductSpecificationCategory;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductSpecificationDetail;

namespace Wardakstudio.Services.ProductsAPI.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductCategory, ProductCategoryDto>().ReverseMap();
            CreateMap<ProductImage, ProductImageDto>().ReverseMap();
            CreateMap<Producer, ProducerDto>().ReverseMap();
            CreateMap<ProductSpecification, ProductSpecificationDto>().ReverseMap();
            CreateMap<ProductSpecificationCategory, ProductSpecificationCategoryDto>().ReverseMap();
            CreateMap<ProductSpecificationDetail, ProductSpecificationDetailDto>().ReverseMap();
        }
    }
}
