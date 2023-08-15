using CompanyServer.Core.Domain.OrderItems;
using CompanyServer.Core.Domain.ShareKernel;

namespace CompanyServer.UnitTetst.Domain.OrderItems;

public class OrderItemProvider
{
    public static OrderItem CreateOrderItem(Guid companyId, Guid warehouseId, Weight weight = null)
    {
        return OrderItem.Create(Material.Of("111000", "张飞买菜", ""), weight, companyId, warehouseId);
    }
}