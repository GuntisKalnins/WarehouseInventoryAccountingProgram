namespace Tests
{
    using Moq;
    using Xunit;
    using WarehouseInventoryAccountingProgram.Models;
    using System.Collections.Generic;
    using System;
    using WarehouseInventoryAccountingProgram.Interfaces;

    public class SalesRepositoryTests
    {
        [Fact]
        public void GetAllSales_ShouldReturnListOfSales()
        {
            // Arrange
            var mockSalesRepository = new Mock<ISalesRepository>();
            var sales = new List<Sale>
            {
                new Sale { SaleID = 1, ProductID = 1, SaleDate = DateTime.Now, CustomerName = "John Doe", Quantity = 5, TotalAmount = 50.0M },
                new Sale { SaleID = 2, ProductID = 2, SaleDate = DateTime.Now.AddDays(-1), CustomerName = "Jane Smith", Quantity = 3, TotalAmount = 30.0M }
            };
            mockSalesRepository.Setup(repo => repo.GetAllSales()).Returns(sales);
            var salesRepository = mockSalesRepository.Object;

            // Act
            List<Sale> result = salesRepository.GetAllSales();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(sales.Count, result.Count);
        }

        [Fact]
        public void GetAllSales_ReturnsEmptyListWhenNoSalesExist()
        {
            // Arrange
            var mockSalesRepository = new Mock<ISalesRepository>();
            var emptySalesList = new List<Sale>();
            mockSalesRepository.Setup(repo => repo.GetAllSales()).Returns(emptySalesList);
            var salesRepository = mockSalesRepository.Object;

            // Act
            List<Sale> result = salesRepository.GetAllSales();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void GetAllSales_HandlesDatabaseException()
        {
            // Arrange
            var mockSalesRepository = new Mock<ISalesRepository>();
            mockSalesRepository.Setup(repo => repo.GetAllSales()).Throws(new Exception("Database connection error"));
            var salesRepository = mockSalesRepository.Object;

            // Act & Assert
            Assert.Throws<Exception>(() => salesRepository.GetAllSales());
        }
    }
}
