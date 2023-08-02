using CompanyServer.Core.Application.Configuration.Commands;

namespace CompanyServer.Core.Application.Warehouses.Commands;

public class DeleteWarehouseCommand : ICommand<bool>
{
    public DeleteWarehouseCommand(Guid warehouseId)
    {
        WarehouseId = warehouseId;
    }
    public Guid WarehouseId { get; set; }
}