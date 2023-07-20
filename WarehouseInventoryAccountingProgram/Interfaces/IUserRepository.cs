namespace WarehouseInventoryAccountingProgram.Interfaces
{
    public interface IUserRepository
    {
        bool ValidateUser(string username, string password);
    }
}
