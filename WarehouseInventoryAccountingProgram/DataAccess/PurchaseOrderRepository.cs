namespace WarehouseInventoryAccountingProgram.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.SqlClient;
    using WarehouseInventoryAccountingProgram.Interfaces;
    using WarehouseInventoryAccountingProgram.Models;

    /// <summary>
    /// Data access for purchase orders.
    /// </summary>
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        private string connectionString;

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
            if (purchaseOrder == null || purchaseOrder.ProductID <= 0 || purchaseOrder.SupplierID <= 0 || purchaseOrder.Quantity <= 0 || purchaseOrder.Cost <= 0 || purchaseOrder.PurchaseDate == DateTime.MinValue)
            {
                throw new ArgumentException("Invalid purchase order data");
            }

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

        /// <summary>
        /// Retrieves all purchase orders from the database.
        /// </summary>
        /// <returns>A list of purchase orders.</returns>
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
