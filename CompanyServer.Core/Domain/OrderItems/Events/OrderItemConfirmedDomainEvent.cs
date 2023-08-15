using CompanyServer.Core.Domain.SeedWork;

namespace CompanyServer.Core.Domain.OrderItems.Events;

public class OrderItemConfirmedDomainEvent : DomainEventBase
{
    public Guid OrderItemId { get; }

    public OrderItemConfirmedDomainEvent(Guid orderItemId)
    {
        OrderItemId = orderItemId;
    }
}