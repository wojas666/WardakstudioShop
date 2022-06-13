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
    public static class MockProductRepository
    {
        public static Mock<IProductRepository> GetProductRepository()
        {
            var products = new List<Product>
            {
                new Product()
                {
                    Id = 1,
                    Price = 5m,
                    DateCreated = DateTime.Now,
                    Name = "Pierwszy produkt",
                    IsPublished = true,
                    Description = "Lorem ipsum dolor.Lorem ipsum dolor.Lorem ipsum dolor.Lorem ipsum dolor.Lorem ipsum dolor.Lorem ipsum dolor.Lorem ipsum dolor.Lorem ipsum dolor.Lorem ipsum dolor.",
                    AvailableQuantity = 5
                },
                new Product()
                {
                    Id = 2,
                    Price = 18m,
                    DateCreated = DateTime.Now,
                    Name = "Drugi produkt",
                    IsPublished = true,
                    Description = "Lorem ipsum dolor.Lorem ipsum dolor.Lorem ipsum dolor.Lorem ipsum dolor.Lorem ipsum dolor.Lorem ipsum dolor.Lorem ipsum dolor.Lorem ipsum dolor.Lorem ipsum dolor.",
                    AvailableQuantity = 8
                },
                new Product()
                {
                    Id = 3,
                    Price = 65m,
                    DateCreated = DateTime.Now,
                    Name = "Trzeci produkt",
                    IsPublished = true,
                    Description = "Lorem ipsum dolor.Lorem ipsum dolor.Lorem ipsum dolor.Lorem ipsum dolor.Lorem ipsum dolor.Lorem ipsum dolor.Lorem ipsum dolor.Lorem ipsum dolor.Lorem ipsum dolor.",
                    AvailableQuantity = 5
                }
            };

            var mockRepository = new Mock<IProductRepository>();

            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(products);
            mockRepository.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                var product = products.Find(x => x.Id == id);
                return product;
            });

            return mockRepository;
        }
    }
}
