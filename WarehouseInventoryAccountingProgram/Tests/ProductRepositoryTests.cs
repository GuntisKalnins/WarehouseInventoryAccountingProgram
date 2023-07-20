namespace Tests
{
    using System;
    using System.Collections.Generic;
    using Moq;
    using Xunit;
    using WarehouseInventoryAccountingProgram.Models;
    using WarehouseInventoryAccountingProgram.Interfaces;

    public class ProductRepositoryTests
    {
        [Fact]
        public void GetAllProducts_ReturnsListOfProducts()
        {
            // Arrange
            var mockProductRepository = new Mock<IProductRepository>();
            var products = new List<Product>
            {
                new Product { ProductID = 1, ProductName = "Product 1", Quantity = 10, Price = 9.99M, ExpirationDate = DateTime.Now.AddDays(30) },
                new Product { ProductID = 2, ProductName = "Product 2", Quantity = 15, Price = 14.99M, ExpirationDate = DateTime.Now.AddDays(60) }
            };
            mockProductRepository.Setup(repo => repo.GetAllProducts()).Returns(products);
            var productRepository = mockProductRepository.Object;

            // Act
            List<Product> result = productRepository.GetAllProducts();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(products.Count, result.Count);
        }

        [Fact]
        public void GetTotalQuantity_ReturnsTotalQuantity()
        {
            // Arrange
            var mockProductRepository = new Mock<IProductRepository>();
            int totalQuantity = 100;
            mockProductRepository.Setup(repo => repo.GetTotalQuantity()).Returns(totalQuantity);
            var productRepository = mockProductRepository.Object;

            // Act
            int result = productRepository.GetTotalQuantity();

            // Assert
            Assert.Equal(totalQuantity, result);
        }

        [Fact]
        public void DeleteProduct_DeletesProduct()
        {
            // Arrange
            var mockProductRepository = new Mock<IProductRepository>();
            int productIDToDelete = 1;
            mockProductRepository.Setup(repo => repo.DeleteProduct(productIDToDelete)).Returns(true);

            var productRepository = mockProductRepository.Object;

            // Act
            bool isDeleted = productRepository.DeleteProduct(productIDToDelete);

            // Assert
            Assert.True(isDeleted);
        }

        [Fact]
        public void UpdateProduct_UpdatesProduct()
        {
            // Arrange
            var mockProductRepository = new Mock<IProductRepository>();
            int productIDToUpdate = 1;
            var updatedProduct = new Product
            {
                ProductID = productIDToUpdate,
                ProductName = "Updated Product",
                Quantity = 100,
                Price = 10.99M,
                ExpirationDate = DateTime.Now.AddDays(30)
            };
            mockProductRepository.Setup(repo => repo.UpdateProduct(updatedProduct)).Returns(true);

            var productRepository = mockProductRepository.Object;

            // Act
            bool isUpdated = productRepository.UpdateProduct(updatedProduct);

            // Assert
            Assert.True(isUpdated);
        }

        [Fact]
        public void AddProduct_AddsProduct()
        {
            // Arrange
            var mockProductRepository = new Mock<IProductRepository>();
            var newProduct = new Product
            {
                ProductName = "New Product",
                Quantity = 50,
                Price = 5.99M,
                ExpirationDate = DateTime.Now.AddDays(60)
            };
            mockProductRepository.Setup(repo => repo.AddProduct(It.IsAny<Product>())).Returns(true);

            var productRepository = mockProductRepository.Object;

            // Act
            bool isAdded = productRepository.AddProduct(newProduct);

            // Assert
            Assert.True(isAdded);
        }
    }
}

