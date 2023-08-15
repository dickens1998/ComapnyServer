using System.ComponentModel;

namespace CompanyServer.Core.Domain.OrderItems;

public enum OrderItemStatus
{
    [Description("准备")]
    Ready = 0,
    [Description("确认")]
    Confirmed = 10,
    [Description("退货 (部分)")]
    Return = 20,
    
}