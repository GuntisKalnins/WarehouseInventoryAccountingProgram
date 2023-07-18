namespace WarehouseInventoryAccountingProgram.Models
{
    /// <summary>
    /// Represents a supplier.
    /// </summary>
    public class Supplier
    {
        /// <summary>
        /// Gets or sets the supplier ID.
        /// </summary>
        public int SupplierID { get; set; }

        /// <summary>
        /// Gets or sets the name of the supplier.
        /// </summary>
        public string SupplierName { get; set; }

        /// <summary>
        /// Gets or sets the contact person for the supplier.
        /// </summary>
        public string ContactPerson { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the supplier.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the email address of the supplier.
        /// </summary>
        public string Email { get; set; }
    }
}
