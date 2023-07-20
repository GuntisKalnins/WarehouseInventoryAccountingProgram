namespace WarehouseInventoryAccountingProgram.Models
{
    using System;

    /// <summary>
    /// Product in the inventory.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Unique identifier for the product.
        /// </summary>
        public int ProductID { get; set; }

        /// <summary>
        /// Name of the product.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Quantity of the product.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Price of the product.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Expiration date of the product.
        /// </summary>
        public DateTime ExpirationDate { get; set; }
    }
}