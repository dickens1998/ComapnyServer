using CompanyServer.Core.Domain.OrderItems.Events;
using CompanyServer.Core.Domain.OrderItems.Exceptions;
using CompanyServer.Core.Domain.SeedWork;
using CompanyServer.Core.Domain.ShareKernel;

namespace CompanyServer.Core.Domain.OrderItems;

public class OrderItem : Entity, IAggregateRoot
{
    private OrderItem()
    {
    }

    public OrderItem(Material material, Weight weight, Guid companyId, Guid warehouseId)
    {
        Id = Guid.NewGuid();
        CreateTime = DateTime.Now;
        Status = OrderItemStatus.Ready;
        Material = material;
        Weight = weight;
        WarehouseId = warehouseId;
        CompanyId = companyId;
    }

    public Guid Id { get; private set; }
    public Guid CompanyId { get; private set; }
    public Guid WarehouseId { get; private set; }
    public DateTime CreateTime { get; private set; }
    public Material Material { get; private set; }
    public OrderItemStatus Status { get; private set; }
    public Weight Weight { get; private set; }
    public List<Goods> GoodsList { get; private set; } = new();

    public static OrderItem Create(Material material, Weight weight, Guid companyId, Guid warehouseId) =>
        new(material, weight, companyId, warehouseId);

    public void AddGoods(Weight weight, UnitPrice unitPrice = null, Weight returnWeight = null)
    {
        // 获取已经退的Weight
        if (GoodsList.Any() && returnWeight != null)
        {
            var thisReturnWeights = GoodsList.Where(x => x.ReturnWeight != null).Sum(x => x.ReturnWeight.Value);

            if (Weight.Of(returnWeight.Value + thisReturnWeights, Weight.Unit) > Weight)
            {
                throw new ReturnGoodsWeightLimitedOfTotalWeightException(returnWeight, Weight);
            }
        }

        var goods = new Goods(Id, Material.Number, weight, unitPrice);
        goods.Return(returnWeight);
        GoodsList.Add(goods);
    }

    public void AddGoodsList(List<Goods> goodsList)
    {
        GoodsList.AddRange(goodsList);
    }

    public void ReturnWeight(Weight weight)
    {
        Status = OrderItemStatus.Return;
        AddDomainEvent(new OrderItemReturnedDomainEvent(Id, Material, weight));
    }

    public void Confirm()
    {
        if (Status == OrderItemStatus.Confirmed) return;
        Status = OrderItemStatus.Confirmed;
    }
}