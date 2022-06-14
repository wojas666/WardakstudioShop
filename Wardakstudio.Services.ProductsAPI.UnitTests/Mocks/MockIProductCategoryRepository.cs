using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;

namespace Wardakstudio.Services.ProductsAPI.UnitTests.Mocks
{
    public static class MockIProductCategoryRepository
    {
        public static Mock<IProductCategoryRepository> GetMockProdoctCategoryRepository()
        {
            var productCategories = new List<ProductCategory>
            {
                new ProductCategory()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    CategoryName = "Testowa kategoria",
                    CategoryUrlSeo = "/testowa-kategoria/",
                }
            };

            Mock<IProductCategoryRepository> _mockRepo = new Mock<IProductCategoryRepository>();

            _mockRepo.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                var productCategory = productCategories.Find(x => x.Id == id);
                return productCategory;
            });

            _mockRepo.Setup(x => x.Exists(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                var productCategory = productCategories.FirstOrDefault(y => y.Id == id);

                return productCategory != null ? true : false;
            });

            return _mockRepo;
        }
    }
}
