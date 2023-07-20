namespace Tests
{
    using System;
    using System.Collections.Generic;
    using Moq;
    using Xunit;
    using WarehouseInventoryAccountingProgram.Models;
    using WarehouseInventoryAccountingProgram.Interfaces;

    public class StockEntryRepositoryTests
    {        
        [Fact]

        public void GetAllSuppliers_ReturnsEmptyListWhenNoSuppliersExist()
        {
            // Arrange
            var mockStockEntryRepository = new Mock<IStockEntryRepository>();
            var emptySuppliersList = new List<Supplier>();
            mockStockEntryRepository.Setup(repo => repo.GetAllSuppliers()).Returns(emptySuppliersList);
            var stockEntryRepository = mockStockEntryRepository.Object;

            // Act
            List<Supplier> result = stockEntryRepository.GetAllSuppliers();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void GetAllSuppliers_HandlesDatabaseException()
        {
            // Arrange
            var mockStockEntryRepository = new Mock<IStockEntryRepository>();
            mockStockEntryRepository.Setup(repo => repo.GetAllSuppliers()).Throws(new Exception("Database connection error"));
            var stockEntryRepository = mockStockEntryRepository.Object;

            // Act & Assert
            Assert.Throws<Exception>(() => stockEntryRepository.GetAllSuppliers());
        }
    }
}
