﻿using Wardakstudio.Services.ProductsAPI.Models;


namespace Wardakstudio.Services.ProductsAPI.Repository
{
    public interface IProductSpecificationRepository : IGenericRepository<ProductSpecification>
    {
        Task<List<ProductSpecification>> GetProductSpecificationsListForProduct(int productId);

    }
}
