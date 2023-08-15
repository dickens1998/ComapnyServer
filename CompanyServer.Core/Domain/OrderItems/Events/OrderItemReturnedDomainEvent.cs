using CompanyServer.Core.Domain.SeedWork;
using CompanyServer.Core.Domain.ShareKernel;

namespace CompanyServer.Core.Domain.OrderItems.Events;

public class OrderItemReturnedDomainEvent : DomainEventBase
{
    public OrderItemReturnedDomainEvent(Guid orderItemId, Material material, Weight weight)
    {
        OrderItemId = orderItemId;
        Material = material;
        Weight = weight;
    }

    public Guid OrderItemId { get; set; }
    public Material Material { get; }
    public Weight Weight { get; }
}