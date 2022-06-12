using AutoMapper;
using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.Producer;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.Product;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductCategory;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductImage;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductRating;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductSpecification;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductSpecificationCategory;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductSpecificationDetail;

namespace Wardakstudio.Services.ProductsAPI.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Product
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            #endregion

            #region ProductCategory
            CreateMap<ProductCategory, ProductCategoryDto>().ReverseMap();
            CreateMap<ProductCategory, CreateProductCategoryDto>().ReverseMap();
            CreateMap<ProductCategory, UpdateProductCategoryDto>().ReverseMap();
            #endregion

            #region ProductImage
            CreateMap<ProductImage, ProductImageDto>().ReverseMap();
            CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
            #endregion

            #region ProductRating
            CreateMap<ProductRating, ProductRatingDto>().ReverseMap();
            CreateMap<ProductRating, CreateProductRatingDto>().ReverseMap();
            #endregion

            #region Producer
            CreateMap<Producer, ProducerDto>().ReverseMap();
            CreateMap<Producer, CreateProducerDto>().ReverseMap();
            CreateMap<Producer, UpdateProducerDto>().ReverseMap();

            #endregion

            #region ProductSpecification
            CreateMap<ProductSpecification, ProductSpecificationDto>().ReverseMap();
            CreateMap<ProductSpecification, CreateProductSpecificationDto>().ReverseMap();
            #endregion

            #region ProductSpecificationCategory
            CreateMap<ProductSpecificationCategory, ProductSpecificationCategoryDto>().ReverseMap();
            CreateMap<ProductSpecificationCategory, CreateProductSpecificationCategoryDto>().ReverseMap();
            #endregion

            #region ProductSpecificationDetail
            CreateMap<ProductSpecificationDetail, ProductSpecificationDetailDto>().ReverseMap();
            CreateMap<ProductSpecificationDetail, CreateProductSpecificationDetailDto>().ReverseMap();
            #endregion
        }
    }
}
