using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardakstudio.Services.ProductsAPI.DbContexts;
using Wardakstudio.Services.ProductsAPI.Repository;

namespace Wardakstudio.Services.ProductsAPI.UnitTests.Repositories.Product
{
    public class GetSearchProductsListTests
    {
        public GetSearchProductsListTests()
        {
            var mockDbContext = new Mock<ApplicationDbContext>();

            var productRepository = new ProductRepository()
        }
    }
}
