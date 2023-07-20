namespace WarehouseInventoryAccountingProgram.DataAccess
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.SqlClient;
    using WarehouseInventoryAccountingProgram.Interfaces;
    using WarehouseInventoryAccountingProgram.Models;

    public class SupplierRepository : ISupplierRepository
    {
        private string connectionString;

        public SupplierRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        /// <summary>
        /// Retrieves all suppliers from the database.
        /// </summary>
        /// <returns>A list of Supplier objects representing all suppliers.</returns>
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
    }
}
