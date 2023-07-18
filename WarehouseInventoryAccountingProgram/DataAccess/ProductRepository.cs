namespace WarehouseInventoryAccountingProgram.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.SqlClient;
    using WarehouseInventoryAccountingProgram.Models;

    /// <summary>
    /// Provides data access methods for managing products.
    /// </summary>
    public class ProductRepository
    {
        private string connectionString;

        /// <summary>
        /// Initializes a new instance of the ProductRepository class.
        /// </summary>
        public ProductRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        /// <summary>
        /// Retrieves all products from the database.
        /// </summary>
        /// <returns>A list of Product objects representing all products.</returns>
        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT ProductID, ProductName, Quantity, Price, ExpirationDate FROM Products";
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Product product = new Product
                    {
                        ProductID = (int)reader["ProductID"],
                        ProductName = (string)reader["ProductName"],
                        Quantity = (int)reader["Quantity"],
                        Price = (decimal)reader["Price"],
                        ExpirationDate = (DateTime)reader["ExpirationDate"]
                    };

                    products.Add(product);
                }

                reader.Close();
                connection.Close();
            }

            return products;
        }

        /// <summary>
        /// Retrieves the total quantity of all products in the database.
        /// </summary>
        /// <returns>The total quantity of all products.</returns>
        public int GetTotalQuantity()
        {
            int totalQuantity = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT SUM(Quantity) AS TotalQuantity FROM Products";
                SqlCommand command = new SqlCommand(query, connection);

                object result = command.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    totalQuantity = (int)result;
                }

                connection.Close();
            }

            return totalQuantity;
        }

        /// <summary>
        /// Deletes a product from the database based on the provided product ID.
        /// </summary>
        /// <param name="productID">The ID of the product to be deleted.</param>
        /// <returns>True if the product was deleted successfully; otherwise, false.</returns>
        public bool DeleteProduct(int productID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Products WHERE ProductID = @ProductID";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ProductID", productID);

                int rowsAffected = command.ExecuteNonQuery();

                connection.Close();

                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Updates a product in the database.
        /// </summary>
        /// <param name="product">The product to be updated.</param>
        /// <returns><c>true</c> if the product is successfully updated; otherwise, <c>false</c>.</returns>
        public bool UpdateProduct(Product product)
        {
            bool isUpdated = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE Products SET ProductName = @ProductName, Quantity = @Quantity, Price = @Price, ExpirationDate = @ExpirationDate WHERE ProductID = @ProductID";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ProductName", product.ProductName);
                command.Parameters.AddWithValue("@Quantity", product.Quantity);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@ExpirationDate", product.ExpirationDate);
                command.Parameters.AddWithValue("@ProductID", product.ProductID);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    isUpdated = true;
                }

                connection.Close();
            }

            return isUpdated;
        }

        /// <summary>
        /// Adds a new product to the database.
        /// </summary>
        /// <param name="product">The product to add.</param>
        /// <returns>True if the product is added successfully, false otherwise.</returns>
        public bool AddProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Products (ProductName, Quantity, Price, ExpirationDate) " +
                               "VALUES (@ProductName, @Quantity, @Price, @ExpirationDate)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ProductName", product.ProductName);
                command.Parameters.AddWithValue("@Quantity", product.Quantity);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@ExpirationDate", product.ExpirationDate);

                int rowsAffected = command.ExecuteNonQuery();

                connection.Close();

                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Updates the quantity of a product in the inventory.
        /// </summary>
        /// <param name="productID">The ID of the product.</param>
        /// <param name="quantity">The new quantity value.</param>
        public void UpdateProductQuantity(int productID, int quantity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE Products SET Quantity = @Quantity WHERE ProductID = @ProductID";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Quantity", quantity);
                command.Parameters.AddWithValue("@ProductID", productID);

                command.ExecuteNonQuery();

                connection.Close();
            }
        
        }
    }
}
