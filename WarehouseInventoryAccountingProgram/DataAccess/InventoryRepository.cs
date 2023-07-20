namespace WarehouseInventoryAccountingProgram.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.SqlClient;
    using WarehouseInventoryAccountingProgram.Models;

    public class InventoryRepository
    {
        private string connectionString;

        public InventoryRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        /// <summary>
        /// Retrieves the inventory report within the specified time frame.
        /// </summary>
        /// <param name="startDate">The start date of the time frame.</param>
        /// <param name="endDate">The end date of the time frame.</param>
        /// <returns>A list of InventoryItem objects representing the inventory report.</returns>
        public List<InventoryItem> GetInventoryReport(DateTime startDate, DateTime endDate)
        {
            List<InventoryItem> inventory = new List<InventoryItem>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT P.ProductID, P.ProductName, I.Quantity, P.Price FROM Products P INNER JOIN InventoryItems I ON P.ProductID = I.ProductID WHERE I.EntryDate BETWEEN @StartDate AND @EndDate";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    InventoryItem item = new InventoryItem
                    {
                        ProductID = (int)reader["ProductID"],
                        ProductName = (string)reader["ProductName"],
                        Quantity = (int)reader["Quantity"],
                        Price = (decimal)reader["Price"]
                    };

                    inventory.Add(item);
                }

                reader.Close();
                connection.Close();
            }

            return inventory;
        }
    }
}
