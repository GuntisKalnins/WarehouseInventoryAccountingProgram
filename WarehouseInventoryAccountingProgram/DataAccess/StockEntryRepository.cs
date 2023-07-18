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

        public void AddStockEntry(StockEntry stockEntry)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Prepare the SQL query to insert the stock entry into the database
                string query = "INSERT INTO StockEntries (ProductID, SupplierID, EntryDate, Quantity) VALUES (@ProductID, @SupplierID, @EntryDate, @Quantity)";
                SqlCommand command = new SqlCommand(query, connection);

                // Set the parameter values
                command.Parameters.AddWithValue("@ProductID", stockEntry.ProductID);
                command.Parameters.AddWithValue("@SupplierID", stockEntry.SupplierID);
                command.Parameters.AddWithValue("@EntryDate", stockEntry.EntryDate);
                command.Parameters.AddWithValue("@Quantity", stockEntry.Quantity);

                // Execute the query
                command.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}
