using CompanyServer.Core.Domain.OrderItems;
using NUnit.Framework;
using Shouldly;

namespace CompanyServer.UnitTetst.Domain.OrderItems;

public class ConfirmOrderItemTests
{
    [Test]
    public void ShouldConfirmOrderItem()
    {
        var orderItem = OrderItemProvider.CreateOrderItem(Guid.NewGuid(), Guid.NewGuid());
        orderItem.Status.ShouldBe(OrderItemStatus.Ready);
        
        orderItem.Confirm();
        orderItem.Status.ShouldBe(OrderItemStatus.Confirmed);
    }
    
    [Test]
    public void ShouldConfirmAgain()
    {
        var orderItem = OrderItemProvider.CreateOrderItem(Guid.NewGuid(), Guid.NewGuid());
        orderItem.Confirm();
        orderItem.Status.ShouldBe(OrderItemStatus.Confirmed);

        orderItem.Confirm();
        orderItem.Status.ShouldBe(OrderItemStatus.Confirmed);
    }
}