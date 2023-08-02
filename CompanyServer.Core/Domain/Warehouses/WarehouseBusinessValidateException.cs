namespace CompanyServer.Core.Domain.Warehouses;

public class WarehouseBusinessValidateException : Exception
{
    public WarehouseBusinessValidateException(string message) : base(message)
    {
    }
}