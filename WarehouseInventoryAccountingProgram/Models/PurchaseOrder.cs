namespace WarehouseInventoryAccountingProgram.Models
{
    using System;

    /// <summary>
    /// Represents a purchase order for restocking products.
    /// </summary>
    public class PurchaseOrder
    {
        /// <summary>
        /// Gets or sets the purchase order ID.
        /// </summary>
        public int PurchaseOrderID { get; set; }

        /// <summary>
        /// Gets or sets the ID of the product being ordered.
        /// </summary>
        public int ProductID { get; set; }

        /// <summary>
        /// Gets or sets the ID of the supplier from whom the product is being ordered.
        /// </summary>
        public int SupplierID { get; set; }

        /// <summary>
        /// Gets or sets the date of the purchase order.
        /// </summary>
        public DateTime PurchaseDate { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product being ordered.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the cost per unit of the product being ordered.
        /// </summary>
        public decimal Cost { get; set; }

    }
}