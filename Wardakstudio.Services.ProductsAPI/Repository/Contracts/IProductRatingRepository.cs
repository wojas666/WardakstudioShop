using Wardakstudio.Services.ProductsAPI.Models;

namespace Wardakstudio.Services.ProductsAPI.Repository.Contracts
{
    public interface IProductRatingRepository : IGenericRepository<ProductRating>
    {
        Task<List<ProductRating>> GetProductRatings(int productId);

        Task ChangeApprovalStatus(ProductRating productRating, bool? isApproved);
    }
}
