namespace WarehouseInventoryAccountingProgram.Models
{
    using System;

    /// <summary>
    /// Sale transaction.
    /// </summary>
    public class Sale
    {
        /// <summary>
        /// Sale ID.
        /// </summary>
        public int SaleID { get; set; }

        /// <summary>
        /// Product ID associated with the sale.
        /// </summary>
        public int ProductID { get; set; }

        /// <summary>
        /// Sale date.
        /// </summary>
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// Name of the customer associated with the sale.
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// The quantity sold.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Total amount of the sale.
        /// </summary>
        public decimal TotalAmount { get; set; }
    }
}
