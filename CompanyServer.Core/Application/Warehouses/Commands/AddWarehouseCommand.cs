using CompanyServer.Core.Application.Configuration.Commands;

namespace CompanyServer.Core.Application.Warehouses.Commands;

public class AddWarehouseCommand : ICommand<Guid>
{
    public Guid CompanyId { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
}