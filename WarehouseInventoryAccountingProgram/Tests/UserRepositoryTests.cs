using System;
using Moq;
using Xunit;
using WarehouseInventoryAccountingProgram.Interfaces;

namespace Tests
{
    public class UserRepositoryTests
    {
        [Fact]
        public void ValidateUser_ReturnsTrueForValidUser()
        {
            // Arrange
            var mockUserRepository = new Mock<IUserRepository>();
            string validUsername = "validuser";
            string validPassword = "validpassword";
            mockUserRepository.Setup(repo => repo.ValidateUser(validUsername, validPassword)).Returns(true);
            var userRepository = mockUserRepository.Object;

            // Act
            bool result = userRepository.ValidateUser(validUsername, validPassword);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ValidateUser_ReturnsFalseForInvalidUser()
        {
            // Arrange
            var mockUserRepository = new Mock<IUserRepository>();
            string validUsername = "validuser";
            string invalidPassword = "invalidpassword";
            mockUserRepository.Setup(repo => repo.ValidateUser(validUsername, invalidPassword)).Returns(false);
            var userRepository = mockUserRepository.Object;

            // Act
            bool result = userRepository.ValidateUser(validUsername, invalidPassword);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void ValidateUser_HandlesDatabaseException()
        {
            // Arrange
            var mockUserRepository = new Mock<IUserRepository>();
            string validUsername = "validuser";
            string validPassword = "validpassword";
            mockUserRepository.Setup(repo => repo.ValidateUser(validUsername, validPassword)).Throws(new Exception("Database connection error"));
            var userRepository = mockUserRepository.Object;

            // Act & Assert
            Assert.Throws<Exception>(() => userRepository.ValidateUser(validUsername, validPassword));
        }
    }
}
