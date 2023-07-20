namespace WarehouseInventoryAccountingProgram.Interfaces
{
    using System.Collections.Generic;
    using WarehouseInventoryAccountingProgram.Models;

    public interface IPurchaseOrderRepository
    {
        void AddPurchaseOrder(PurchaseOrder purchaseOrder);
        List<PurchaseOrder> GetAllPurchaseOrders();
    }
}
