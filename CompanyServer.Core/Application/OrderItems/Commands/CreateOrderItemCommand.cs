using CompanyServer.Core.Application.Configuration.Commands;
using CompanyServer.Core.Domain.ShareKernel;

namespace CompanyServer.Core.Application.OrderItems.Commands;

public class CreateOrderItemCommand : ICommand<bool>
{
    public Guid CompanyId { get; set; }
    public Guid WarehouseId { get; set; }
    public Material Material { get; set; }
    public Weight Weight { get; set; }
}