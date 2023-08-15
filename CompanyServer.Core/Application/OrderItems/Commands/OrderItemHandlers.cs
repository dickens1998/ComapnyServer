using CompanyServer.Core.Application.OrderItems.Services;
using MediatR;

namespace CompanyServer.Core.Application.OrderItems.Commands;

public class OrderItemHandlers : IRequestHandler<CreateOrderItemCommand, bool>,
    IRequestHandler<ReturnSetWeightOrderItemCommand, bool>
{
    private readonly IOrderItemService _orderItemService;

    public OrderItemHandlers(IOrderItemService orderItemService)
    {
        _orderItemService = orderItemService;
    }

    public async Task<bool> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
    {
        await _orderItemService.CreateAsync(request);
        return true;
    }

    public async Task<bool> Handle(ReturnSetWeightOrderItemCommand request, CancellationToken cancellationToken)
    {
        await _orderItemService.ReturnOrderItemAsync(request);
        return true;
    }
}