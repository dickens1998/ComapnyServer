using CompanyServer.Core.Data;
using CompanyServer.Core.Domain.OrderItems;
using CompanyServer.Core.Domain.OrderItems.Events;
using MediatR;

namespace CompanyServer.Core.Application.OrderItems.EventHanlders;

public class OrderItemReturnedDomainEventHandler : INotificationHandler<OrderItemReturnedDomainEvent>
{
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly CompanyServerDbContext _dbContext;

    public OrderItemReturnedDomainEventHandler(IOrderItemRepository orderItemRepository, CompanyServerDbContext dbContext)
    {
        _orderItemRepository = orderItemRepository;
        _dbContext = dbContext;
    }

    public async Task Handle(OrderItemReturnedDomainEvent notification, CancellationToken cancellationToken)
    {
        var orderItem = await _orderItemRepository.GetById(notification.OrderItemId);
        if (orderItem == null)
            throw new Exception("orderItem not found.");
        
    }
}