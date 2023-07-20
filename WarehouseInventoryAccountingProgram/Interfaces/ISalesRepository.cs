namespace WarehouseInventoryAccountingProgram.Interfaces
{
    using System.Collections.Generic;
    using WarehouseInventoryAccountingProgram.Models;

    public interface ISalesRepository
    {
        void AddSale(Sale sale);
        List<Sale> GetAllSales();
    }
}
