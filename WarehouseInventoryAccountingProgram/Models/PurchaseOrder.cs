namespace WarehouseInventoryAccountingProgram.Models
{
    using System;

    /// <summary>
    /// Purchase order for restocking products.
    /// </summary>
    public class PurchaseOrder
    {
        /// <summary>
        /// Purchase order ID.
        /// </summary>
        public int PurchaseOrderID { get; set; }

        /// <summary>
        /// ID of the product being ordered.
        /// </summary>
        public int ProductID { get; set; }

        /// <summary>
        /// ID of the supplier from whom the product is being ordered.
        /// </summary>
        public int SupplierID { get; set; }

        /// <summary>
        /// Date of the purchase order.
        /// </summary>
        public DateTime PurchaseDate { get; set; }

        /// <summary>
        /// Quantity of the product being ordered.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Cost per unit of the product being ordered.
        /// </summary>
        public decimal Cost { get; set; }

    }
}