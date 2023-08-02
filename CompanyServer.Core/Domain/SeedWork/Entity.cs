namespace CompanyServer.Core.Domain.SeedWork;

/// <summary>
///  主要实现一个抽象类Entity
/// 为领域模型提供一种机制来收集和管理领域事件。领域事件可以用于表示业务中发生的重要事务或状态变更
/// 例如订单被创建、产品被添加到购物车等。通过收集领域事件，可以在需要的时候触发相应的事件处理逻辑
/// 以实现领域驱动设计（DDD）中的事件驱动架构。
/// </summary>
public abstract class Entity
{
    /// <summary>
    /// _domainEvents 是一个私有字段，它保存了领域事件的列表。
    /// </summary>
    private List<IDomainEvent> _domainEvents;

    /// <summary>
    /// DomainEvents 是一个只读属性，用于获取领域事件的只读集合。它通过将 _domainEvents 转换为只读集合返回，使得外部代码只能读取领域事件，而不能修改它们。
    /// </summary>
    public IReadOnlyCollection<IDomainEvent>? DomainEvents => _domainEvents?.AsReadOnly();

    /// <summary IDomainEvent="对象，并将领域事件添加到列表中。">
    /// AddDomainEvent 方法用于向 _domainEvents 列表添加领域事件
    /// 它首先检查 _domainEvents 是否为 null，如果为 null，则创建一个新的 List
    /// </summary>
    /// <param name="domainEvent"></param>
    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents ??= new List<IDomainEvent>();

        _domainEvents.Add(domainEvent);
    }

    /// <summary>
    /// ClearDomainEvents 方法用于清空 _domainEvents 列表。它首先检查 _domainEvents 是否为 null，如果不为 null，则通过调用 Clear() 方法来清空列表。
    /// </summary>
    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }
}