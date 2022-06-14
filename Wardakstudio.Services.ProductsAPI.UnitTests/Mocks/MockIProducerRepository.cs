using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;
using Moq;
using Wardakstudio.Services.ProductsAPI.Models;

namespace Wardakstudio.Services.ProductsAPI.UnitTests.Mocks
{
    public static class MockIProducerRepository
    {
        public static Mock<IProducerRepository> GetProducerRepository()
        {
            var producers = new List<Producer>
            {
                new Producer()
                {
                    Id = 1,
                    Name = "Heroes Diet",
                    Description = "Lorem ipsum dolor.Lorem ipsum dolor.Lorem ipsum dolor.Lorem ipsum dolor.Lorem ipsum dolor.Lorem ipsum dolor.Lorem ipsum dolor.Lorem ipsum dolor.Lorem ipsum dolor.Lorem ipsum dolor.Lorem ipsum dolor."
                },
                new Producer()
                {
                    Id = 2,
                    Name= "Testowa firma",
                    Description = "Jakaś testowa firma.Jakaś testowa firma.Jakaś testowa firma.Jakaś testowa firma.Jakaś testowa firma.Jakaś testowa firma.Jakaś testowa firma.Jakaś testowa firma.Jakaś testowa firma.Jakaś testowa firma."
                },
                new Producer()
                {
                    Id = 3,
                    Name = "Barpark",
                    Description = "Bar typu fast-food.Bar typu fast-food.Bar typu fast-food.Bar typu fast-food.Bar typu fast-food.Bar typu fast-food.Bar typu fast-food.Bar typu fast-food.Bar typu fast-food.Bar typu fast-food.Bar typu fast-food."
                }
            };

            var mockRepo = new Mock<IProducerRepository>();

            mockRepo.Setup(x => x.GetAll()).ReturnsAsync(producers);
            mockRepo.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                var producer = producers.Find(item => item.Id == id);
                return producer;
            });

            mockRepo.Setup(x=> x.Add(It.IsAny<Producer>())).ReturnsAsync((Producer producer) =>
            {
                producers.Add(producer);
                return producer;
            });
            mockRepo.Setup(x => x.Exists(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                var producer = producers.FirstOrDefault(y => y.Id == id);

                return producer != null ? true : false;
            });

            return mockRepo;
        }
    }
}
