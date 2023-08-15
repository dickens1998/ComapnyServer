using CompanyServer.Core.Domain.SeedWork;
using CompanyServer.Core.Domain.ShareKernel;
using JetBrains.Annotations;

namespace CompanyServer.Core.Domain.OrderItems;

public class Goods : Entity, IAggregateRoot
{
    private Goods()
    {
    }

    public Goods(Guid orderItemId, string materialNumber, Weight weight, [CanBeNull] UnitPrice unitPriceWeight = null,
        [CanBeNull] Weight returnWeight = null
    )
    {
        Id = Guid.NewGuid();
        OrderItemId = orderItemId;
        Weight = weight;
        MaterialNumber = materialNumber;
        UnitPriceWeight = unitPriceWeight;
        Status = GoodsStatus.Ready;
    }

    public Guid Id { get; private set; }
    public Guid OrderItemId { get; set; }
    public string MaterialNumber { get; private set; }
    public Weight Weight { get; private set; }
    public GoodsStatus Status { get; private set; }
    [CanBeNull] public Weight ReturnWeight { get; private set; }
    [CanBeNull] public UnitPrice UnitPriceWeight { get; private set; }

    public override string ToString()
    {
        return $"MaterialNumber: {MaterialNumber}, Weight: {Weight}.";
    }

    public void Return(Weight returnWeight)
    {
        Status = GoodsStatus.Return;
        ReturnWeight = returnWeight;
    }
}