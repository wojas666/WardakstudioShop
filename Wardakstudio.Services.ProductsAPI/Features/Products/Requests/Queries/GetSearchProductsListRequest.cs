using AutoMapper;
using MediatR;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.Product;
using Wardakstudio.Services.ProductsAPI.Repository;

namespace Wardakstudio.Services.ProductsAPI.Features.Products.Requests.Queries
{
    public class GetSearchProductsListRequest : IRequest<List<ProductDto>>
    {
        public SearchProductDto SearchProduct { get; set; }
    }
}
