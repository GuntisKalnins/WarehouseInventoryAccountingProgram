namespace WarehouseInventoryAccountingProgram.Interfaces
{
    using System.Collections.Generic;
    using WarehouseInventoryAccountingProgram.Models;

    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        int GetTotalQuantity();
        bool DeleteProduct(int productID);
        bool UpdateProduct(Product product);
        bool AddProduct(Product product);
        void UpdateProductQuantity(int productID, int quantity);
    }
}