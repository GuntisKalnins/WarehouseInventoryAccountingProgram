namespace WarehouseInventoryAccountingProgram.Models
{
    using System;

    /// <summary>
    /// Sale transaction.
    /// </summary>
    public class Sale
    {
        /// <summary>
        /// Gets or sets the sale ID.
        /// </summary>
        public int SaleID { get; set; }

        /// <summary>
        /// Gets or sets the product ID associated with the sale.
        /// </summary>
        public int ProductID { get; set; }

        /// <summary>
        /// Gets or sets the sale date.
        /// </summary>
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// Gets or sets the name of the customer associated with the sale.
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the quantity sold.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the total amount of the sale.
        /// </summary>
        public decimal TotalAmount { get; set; }
    }
}
