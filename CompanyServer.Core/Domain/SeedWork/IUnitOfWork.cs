namespace CompanyServer.Core.Domain.SeedWork;

/// <summary>
/// 领域模型中可以通过工作单元来统一管理和持久化领域实体的更改。
/// </summary>
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// 该方法用于异步保存对数据库的更改操作
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    
    /// <summary>
    /// 该方法用于异步保存领域实体到数据库
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));
}