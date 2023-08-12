namespace CompanyServer.Core.Domain.SeedWork;

//职责是实现 IDomainEvent 接口，提供领域事件的基本属性和行为。
public class DomainEventBase : IDomainEvent
{
    //用于表示领域事件的唯一标识符。它通过 Guid.NewGuid() 方法在对象创建时生成一个新的唯一标识符，并只提供 getter 方法，确保每个领域事件都有一个唯一的标识符
    public Guid Id { get; } = Guid.NewGuid();
    
    //用于表示领域事件发生的时间。它通过 DateTime.Now 属性在对象创建时获取当前时间，并只提供 getter 方法，确保记录领域事件时使用准确的时间戳。
    public DateTime OccurredOn { get; } = DateTime.Now;
    
    // 可以定义一些额外的属性和行为
}