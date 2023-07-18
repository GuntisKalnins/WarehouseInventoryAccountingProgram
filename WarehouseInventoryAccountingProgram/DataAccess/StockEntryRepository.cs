using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using WarehouseInventoryAccountingProgram.Models;

namespace WarehouseInventoryAccountingProgram.DataAccess
{
    public class StockEntryRepository
    {
        private string connectionString;

        public StockEntryRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        /// <summary>
        /// Retrieves all suppliers from the database.
        /// </summary>
        /// <returns>A list of Supplier objects representing the suppliers.</returns>
        public List<Supplier> GetAllSuppliers()
        {
            List<Supplier> suppliers = new List<Supplier>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT SupplierID, SupplierName, ContactPerson, Phone, Email FROM Suppliers";
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Supplier supplier = new Supplier
                    {
                        SupplierID = (int)reader["SupplierID"],
                        SupplierName = (string)reader["SupplierName"],
                        ContactPerson = (string)reader["ContactPerson"],
                        Phone = (string)reader["Phone"],
                        Email = (string)reader["Email"]
                    };

                    suppliers.Add(supplier);
                }

                reader.Close();
                connection.Close();
            }

            return suppliers;
        }

        /// <summary>
        /// Adds a stock entry to the database and updates the product quantity in the inventory.
        /// </summary>
        /// <param name="stockEntry">The StockEntry object representing the stock entry to be added.</param>
        public void AddStockEntry(StockEntry stockEntry)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO StockEntries (ProductID, SupplierID, EntryDate, Quantity) VALUES (@ProductID, @SupplierID, @EntryDate, @Quantity)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ProductID", stockEntry.ProductID);
                command.Parameters.AddWithValue("@SupplierID", stockEntry.SupplierID);
                command.Parameters.AddWithValue("@EntryDate", stockEntry.EntryDate);
                command.Parameters.AddWithValue("@Quantity", stockEntry.Quantity);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}
