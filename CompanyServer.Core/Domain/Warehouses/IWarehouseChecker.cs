namespace CompanyServer.Core.Domain.Warehouses;

/// <summary>
///  仓库检查器  主要用于执行与仓库相关的检查和计算操作
///   可以使得仓库相关的检查和计算逻辑与具体的实现解耦，并提供代码重用和灵活性。
/// </summary>
public interface IWarehouseChecker
{
    /// <summary>
    /// 用于检查给定公司ID下的仓库名称是否唯一。该方法接受一个公司ID和一个仓库名称作为参数，并返回一个布尔值来指示该名称是否唯一。
    /// 这个方法可以在创建新仓库时进行验证，确保仓库名称在给定公司下是唯一的，避免重复。
    /// </summary>
    /// <param name="companyId"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    bool IsUniqueWithName(Guid companyId, string name);

    
    /// <summary>
    /// 用于计算指定仓库ID下的仓库用户数量。该方法接受一个仓库ID作为参数，并返回一个整数值，表示在该仓库下的用户数量。
    /// 这个方法可以用于统计仓库的用户数量，例如用于权限管理或报告生成等用途。
    /// </summary>
    /// <param name="warehouseId"></param>
    /// <returns></returns>
    int CalculateWarehouseUsers(Guid warehouseId);
}