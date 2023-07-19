namespace WarehouseInventoryAccountingProgram.Models
{
    using System;

    /// <summary>
    /// Represents a stock entry for a product.
    /// </summary>
    public class StockEntry
    {
        /// <summary>
        /// Gets or sets the ID of the stock entry.
        /// </summary>
        public int StockEntryID { get; set; }

        /// <summary>
        /// Gets or sets the ID of the associated product.
        /// </summary>
        public int ProductID { get; set; }

        /// <summary>
        /// Gets or sets the ID of the associated supplier.
        /// </summary>
        public int SupplierID { get; set; }

        /// <summary>
        /// Gets or sets the entry date of the stock entry.
        /// </summary>
        public DateTime EntryDate { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the stock entry.
        /// </summary>
        public int Quantity { get; set; }
    }
}
