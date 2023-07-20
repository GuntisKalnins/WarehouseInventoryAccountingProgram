using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using WarehouseInventoryAccountingProgram.Models;

namespace WarehouseInventoryAccountingProgram.DataAccess
{
    public class PurchaseOrderRepository
    {
        private string connectionString;

        /// <summary>
        /// Handles the data access operations for purchase orders.
        /// </summary>
        public PurchaseOrderRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        /// <summary>
        /// Adds a new purchase order to the database.
        /// </summary>
        /// <param name="purchaseOrder">The purchase order to add.</param>
        public void AddPurchaseOrder(PurchaseOrder purchaseOrder)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Purchases (ProductID, SupplierID, Quantity, Cost, PurchaseDate) VALUES (@ProductID, @SupplierID, @Quantity, @Cost, @PurchaseDate)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ProductID", purchaseOrder.ProductID);
                command.Parameters.AddWithValue("@SupplierID", purchaseOrder.SupplierID);
                command.Parameters.AddWithValue("@Quantity", purchaseOrder.Quantity);
                command.Parameters.AddWithValue("@Cost", purchaseOrder.Cost);
                command.Parameters.AddWithValue("@PurchaseDate", purchaseOrder.PurchaseDate);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public List<PurchaseOrder> GetAllPurchaseOrders()
        {
            List<PurchaseOrder> purchaseOrders = new List<PurchaseOrder>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT PurchaseID, ProductID, SupplierID, Quantity, Cost, PurchaseDate FROM Purchases";
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    PurchaseOrder purchaseOrder = new PurchaseOrder
                    {
                        PurchaseOrderID = (int)reader["PurchaseID"],
                        ProductID = (int)reader["ProductID"],
                        SupplierID = (int)reader["SupplierID"],
                        Quantity = (int)reader["Quantity"],
                        Cost = (decimal)reader["Cost"],
                        PurchaseDate = (DateTime)reader["PurchaseDate"],
                    };

                    purchaseOrders.Add(purchaseOrder);
                }

                reader.Close();
                connection.Close();
            }

            return purchaseOrders;
        }
    }
}
