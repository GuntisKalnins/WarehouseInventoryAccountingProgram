namespace WarehouseInventoryAccountingProgram.Models
{
    using System;

    /// <summary>
    /// Stock entry for a product.
    /// </summary>
    public class StockEntry
    {
        /// <summary>
        /// ID of the stock entry.
        /// </summary>
        public int StockEntryID { get; set; }

        /// <summary>
        /// ID of the associated product.
        /// </summary>
        public int ProductID { get; set; }

        /// <summary>
        /// ID of the associated supplier.
        /// </summary>
        public int SupplierID { get; set; }

        /// <summary>
        /// Entry date of the stock entry.
        /// </summary>
        public DateTime EntryDate { get; set; }

        /// <summary>
        /// Quantity of the stock entry.
        /// </summary>
        public int Quantity { get; set; }
    }
}
