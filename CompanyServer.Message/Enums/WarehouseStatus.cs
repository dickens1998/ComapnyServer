using System.ComponentModel;

namespace CompanyServer.Message.Enums;

public enum WarehouseStatus
{
    [Description("禁用")] Disable = 0,
    [Description("在用")] Active = 1
}