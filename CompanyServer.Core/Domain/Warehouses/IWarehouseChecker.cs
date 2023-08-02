namespace CompanyServer.Core.Domain.Warehouses;

public interface IWarehouseChecker
{
    bool IsUniqueWithName(Guid companyId, string name);

    int CalculateWarehouseUsers(Guid warehouseId);
}