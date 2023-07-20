using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using WarehouseInventoryAccountingProgram.Models;

namespace WarehouseInventoryAccountingProgram.DataAccess
{
    public class SalesRepository
    {
        private string connectionString;

        /// <summary>
        /// Initializes a new instance of the SalesRepository class with the provided connection string.
        /// </summary>
        public SalesRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        /// <summary>
        /// Adds a new sale to the database.
        /// </summary>
        /// <param name="sale">The sale object representing the sale to be added.</param>
        public void AddSale(Sale sale)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Sales (ProductID, SaleDate, CustomerName, Quantity, TotalAmount) VALUES (@ProductID, @SaleDate, @CustomerName, @Quantity, @TotalAmount)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ProductID", sale.ProductID);
                command.Parameters.AddWithValue("@SaleDate", sale.SaleDate);
                command.Parameters.AddWithValue("@CustomerName", sale.CustomerName);
                command.Parameters.AddWithValue("@Quantity", sale.Quantity);
                command.Parameters.AddWithValue("@TotalAmount", sale.TotalAmount);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public List<Sale> GetAllSales()
        {
            List<Sale> sales = new List<Sale>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Prepare the SQL query to retrieve all sales
                string query = "SELECT SaleID, ProductID, SaleDate, CustomerName, Quantity, TotalAmount FROM Sales";
                SqlCommand command = new SqlCommand(query, connection);

                // Execute the query and read the data
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    // Create a new Sale object and populate its properties
                    Sale sale = new Sale
                    {
                        SaleID = (int)reader["SaleID"],
                        ProductID = (int)reader["ProductID"],
                        SaleDate = (DateTime)reader["SaleDate"],
                        CustomerName = (string)reader["CustomerName"],
                        Quantity = (int)reader["Quantity"],
                        TotalAmount = (decimal)reader["TotalAmount"]
                    };

                    // Add the sale to the list
                    sales.Add(sale);
                }

                reader.Close();
                connection.Close();
            }

            return sales;
        }
    }
}
