using CompanyServer.Core.Application.OrderItems.Commands;
using CompanyServer.Core.Services;

namespace CompanyServer.Core.Application.OrderItems.Services;

public interface IOrderItemService : IService
{
    Task CreateAsync(CreateOrderItemCommand command);
    Task ReturnOrderItemAsync(ReturnSetWeightOrderItemCommand command);
}