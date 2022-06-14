using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.Product;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;

namespace Wardakstudio.Services.ProductsAPI.UnitTests.Mocks
{
    public static class MockIProductRepository
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
                    AvailableQuantity = 5,
                    ProducerId = 1,
                    ProductCategoryId = 1
                },
                new Product()
                {
                    Id = 2,
                    Price = 18m,
                    DateCreated = DateTime.Now,
                    Name = "Drugi produkt",
                    IsPublished = true,
                    Description = "Lorem ipsum dolor.Lorem ipsum dolor.Lorem ipsum dolor.Lorem ipsum dolor.Lorem ipsum dolor.Lorem ipsum dolor.Lorem ipsum dolor.Lorem ipsum dolor.Lorem ipsum dolor.",
                    AvailableQuantity = 8,
                    ProductCategoryId = 1
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
            mockRepository.Setup(x => x.GetSearchProductsList(It.IsAny<SearchProductDto>())).ReturnsAsync((SearchProductDto search) =>
            {
                IQueryable<Product> searchedProducts = products.AsQueryable();

                if (!String.IsNullOrEmpty(search.Name))
                    searchedProducts = searchedProducts.Where(x => x.Name.Contains(search.Name));

                if (search.IsAvailable)
                    searchedProducts = searchedProducts.Where(x => x.AvailableQuantity > 0);

                if (search.ProductCategoryIds != null)
                    searchedProducts = searchedProducts.Where(x => search.ProductCategoryIds
                    .Any(y => y == x.ProductCategoryId));

                if (search.MinPrice != null)
                    searchedProducts = searchedProducts.Where(x => x.Price >= search.MinPrice);

                if (search.MaxPrice != null)
                    searchedProducts = searchedProducts.Where(x => x.Price <= search.MaxPrice);

                if (search.ProducerIds != null)
                    searchedProducts = searchedProducts.Where(x => search.ProducerIds
                    .Any(y => y == x.ProducerId));

                switch (search.SortType)
                {
                    case SortType.LowPrice:
                        searchedProducts = searchedProducts.OrderBy(x => x.Price);
                        break;
                    case SortType.HighPrice:
                        searchedProducts = searchedProducts.OrderByDescending(x => x.Price);
                        break;
                    case SortType.NewProduct:
                        searchedProducts = searchedProducts.OrderByDescending(x => x.DateCreated);
                        break;
                }

                return searchedProducts.ToList();
            });

            return mockRepository;
        }
    }
}
