namespace WarehouseInventoryAccountingProgram.Models
{
    /// <summary>
    /// Supplier model.
    /// </summary>
    public class Supplier
    {
        /// <summary>
        /// Supplier ID.
        /// </summary>
        public int SupplierID { get; set; }

        /// <summary>
        /// Name of the supplier.
        /// </summary>
        public string SupplierName { get; set; }

        /// <summary>
        /// Contact person for the supplier.
        /// </summary>
        public string ContactPerson { get; set; }

        /// <summary>
        /// Phone number of the supplier.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Email address of the supplier.
        /// </summary>
        public string Email { get; set; }
    }
}
