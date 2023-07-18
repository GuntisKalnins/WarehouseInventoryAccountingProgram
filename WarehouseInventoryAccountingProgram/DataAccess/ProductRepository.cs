using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using WarehouseInventoryAccountingProgram.Models;

namespace WarehouseInventoryAccountingProgram.DataAccess
{
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
    }
}
