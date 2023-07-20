namespace Tests
{
    using System.Collections.Generic;
    using Moq;
    using Xunit;
    using WarehouseInventoryAccountingProgram.Models;
    using WarehouseInventoryAccountingProgram.Interfaces;
    using System;

    public class SupplierRepositoryTests
    {
        [Fact]
        public void GetAllSuppliers_ReturnsSuppliersWithValidData()
        {
            // Arrange
            var mockSupplierRepository = new Mock<ISupplierRepository>();
            var suppliers = new List<Supplier>
            {
                new Supplier { SupplierID = 1, SupplierName = "Supplier 1", ContactPerson = "Contact 1", Phone = "1234567890", Email = "supplier1@example.com" },
                new Supplier { SupplierID = 2, SupplierName = "Supplier 2", ContactPerson = "Contact 2", Phone = "9876543210", Email = "supplier2@example.com" }
            };
            mockSupplierRepository.Setup(repo => repo.GetAllSuppliers()).Returns(suppliers);
            var supplierRepository = mockSupplierRepository.Object;

            // Act
            List<Supplier> result = supplierRepository.GetAllSuppliers();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(suppliers.Count, result.Count);

            for (int i = 0; i < suppliers.Count; i++)
            {
                Assert.Equal(suppliers[i].SupplierID, result[i].SupplierID);
                Assert.Equal(suppliers[i].SupplierName, result[i].SupplierName);
                Assert.Equal(suppliers[i].ContactPerson, result[i].ContactPerson);
                Assert.Equal(suppliers[i].Phone, result[i].Phone);
                Assert.Equal(suppliers[i].Email, result[i].Email);
            }
        }

        [Fact]
        public void GetAllSuppliers_ReturnsEmptyListWithNoData()
        {
            // Arrange
            var mockSupplierRepository = new Mock<ISupplierRepository>();
            var emptySuppliersList = new List<Supplier>();
            mockSupplierRepository.Setup(repo => repo.GetAllSuppliers()).Returns(emptySuppliersList);
            var supplierRepository = mockSupplierRepository.Object;

            // Act
            List<Supplier> result = supplierRepository.GetAllSuppliers();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void GetAllSuppliers_HandlesDatabaseReadException()
        {
            // Arrange
            var mockSupplierRepository = new Mock<ISupplierRepository>();
            mockSupplierRepository.Setup(repo => repo.GetAllSuppliers()).Throws(new Exception("Database read error"));
            var supplierRepository = mockSupplierRepository.Object;

            // Act & Assert
            Assert.Throws<Exception>(() => supplierRepository.GetAllSuppliers());
        }

        [Fact]
        public void GetAllSuppliers_HandlesDatabaseConnectionException()
        {
            // Arrange
            var mockSupplierRepository = new Mock<ISupplierRepository>();
            mockSupplierRepository.Setup(repo => repo.GetAllSuppliers()).Callback(() => { throw new Exception("Database connection error"); });
            var supplierRepository = mockSupplierRepository.Object;

            // Act & Assert
            Assert.Throws<Exception>(() => supplierRepository.GetAllSuppliers());
        }        
    }
}
