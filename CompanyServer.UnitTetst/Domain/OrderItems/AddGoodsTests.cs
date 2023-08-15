using CompanyServer.Core.Domain.ShareKernel;
using NUnit.Framework;
using Shouldly;

namespace CompanyServer.UnitTetst.Domain.OrderItems;

public class AddGoodsTests
{
    [Test]
    public void ShouldAddGoods()
    {
        var orderItem = OrderItemProvider.CreateOrderItem(Guid.NewGuid(), Guid.NewGuid(), Weight.Of(1000m, "Lb"));

        var weight1 = Weight.OfLb(15.02m);
        var weight2 = Weight.OfLb(16.00m);

        orderItem.AddGoods(weight1);
        orderItem.AddGoods(weight2);

        orderItem.GoodsList.Count.ShouldBe(2);
        orderItem.GoodsList.ShouldContain(m => m.Weight == weight1);
        orderItem.GoodsList.ShouldContain(m => m.Weight == weight2);
    }
}