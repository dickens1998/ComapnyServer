using CompanyServer.Core.Application.Configuration.Commands;
using CompanyServer.Core.Domain.ShareKernel;

namespace CompanyServer.Core.Application.OrderItems.Commands;

public class ReturnSetWeightOrderItemCommand : ICommand<bool>
{
    public Guid OrderItemId { get; set; }
    public Weight ReturnWeight { get; set; }
}