namespace WarehouseInventoryAccountingProgram.Interfaces
{
    using System.Collections.Generic;
    using WarehouseInventoryAccountingProgram.Models;

    public interface IStockEntryRepository
    {
        List<Supplier> GetAllSuppliers();
        void AddStockEntry(StockEntry stockEntry);
    }
}
