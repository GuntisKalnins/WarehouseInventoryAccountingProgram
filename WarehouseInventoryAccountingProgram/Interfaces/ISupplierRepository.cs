namespace WarehouseInventoryAccountingProgram.Interfaces
{
    using System.Collections.Generic;
    using WarehouseInventoryAccountingProgram.Models;

    public interface ISupplierRepository
    {
        List<Supplier> GetAllSuppliers();
    }
}
