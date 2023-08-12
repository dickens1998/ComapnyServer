namespace CompanyServer.Core.Domain.SeedWork;

/// <summary>
/// 仓储类通过依赖注入获得工作单元对象，以保证所有操作在同一个工作单元内进行，从而实现数据的一致性和完整性。
/// 仓储作为一个中介，将应用程序与底层的数据访问层解耦，隐藏了具体的数据存储细节，使得领域模型可以独立于外部数据访问技术进行开发和测试。
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IRepository<T> where T : IAggregateRoot
{
    /// <summary>
    /// 仓储可以获取当前工作单元对象，以确保实体操作在正确的事务范围内进行。
    /// </summary>
    IUnitOfWork UnitOfWork { get; }
}