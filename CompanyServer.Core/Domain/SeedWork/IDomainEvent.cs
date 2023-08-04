using MediatR;

namespace CompanyServer.Core.Domain.SeedWork;

/// <summary>
/// MediatR 在领域驱动设计中 常用的中介者模式库 用于实现对象之间的解耦和消息传递
/// 这里继承 INotification  ，  INotification 是MediatR库提供的一个标记接口，主要用来通知消息
/// 设计的目的是将领域事件定义为可以被通知的消息。通过使用MediatR库，你可以将领域事件发布到一个中央调度器（Mediator），
/// 然后让系统中的其他组件（如命令处理程序、领域服务等）进行订阅和处理这些事件。
/// </summary>
public interface IDomainEvent : INotification
{
    /// <summary>
    /// 设置了只读属性,。用于标识具体领域事件的唯一性
    /// </summary>
    Guid Id { get; }
    /// <summary>
    /// 表示领域事件的发生时间。
    /// </summary>
    DateTime OccurredOn { get; }
}