namespace Tests
{
    using System;
    using System.Collections.Generic;
    using Moq;
    using Xunit;
    using WarehouseInventoryAccountingProgram.Models;
    using WarehouseInventoryAccountingProgram.Interfaces;

    public class PurchaseOrderRepositoryTests
    {
        [Fact]
        public void GetAllPurchaseOrders_ReturnsListOfPurchaseOrders()
        {
            // Arrange
            var mockPurchaseOrderRepository = new Mock<IPurchaseOrderRepository>();
            var purchaseOrders = new List<PurchaseOrder>
            {
                new PurchaseOrder { PurchaseOrderID = 1, ProductID = 1, SupplierID = 1, Quantity = 10, Cost = 100.0M, PurchaseDate = DateTime.Now },
                new PurchaseOrder { PurchaseOrderID = 2, ProductID = 2, SupplierID = 2, Quantity = 5, Cost = 50.0M, PurchaseDate = DateTime.Now.AddDays(-1) }
            };
            mockPurchaseOrderRepository.Setup(repo => repo.GetAllPurchaseOrders()).Returns(purchaseOrders);
            var purchaseOrderRepository = mockPurchaseOrderRepository.Object;

            // Act
            List<PurchaseOrder> result = purchaseOrderRepository.GetAllPurchaseOrders();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(purchaseOrders.Count, result.Count);
        }

        [Fact]
        public void GetAllPurchaseOrders_ReturnsEmptyListWhenNoPurchaseOrdersExist()
        {
            // Arrange
            var mockPurchaseOrderRepository = new Mock<IPurchaseOrderRepository>();
            var emptyPurchaseOrdersList = new List<PurchaseOrder>();
            mockPurchaseOrderRepository.Setup(repo => repo.GetAllPurchaseOrders()).Returns(emptyPurchaseOrdersList);
            var purchaseOrderRepository = mockPurchaseOrderRepository.Object;

            // Act
            List<PurchaseOrder> result = purchaseOrderRepository.GetAllPurchaseOrders();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void GetAllPurchaseOrders_HandlesDatabaseException()
        {
            // Arrange
            var mockPurchaseOrderRepository = new Mock<IPurchaseOrderRepository>();
            mockPurchaseOrderRepository.Setup(repo => repo.GetAllPurchaseOrders()).Throws(new Exception("Database connection error"));
            var purchaseOrderRepository = mockPurchaseOrderRepository.Object;

            // Act & Assert
            Assert.Throws<Exception>(() => purchaseOrderRepository.GetAllPurchaseOrders());
        }
    }
}
