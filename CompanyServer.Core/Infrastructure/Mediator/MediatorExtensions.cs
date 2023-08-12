using CompanyServer.Core.Data;
using CompanyServer.Core.Domain.SeedWork;
using MediatR;

namespace CompanyServer.Core.Infrastructure.Mediator;

/// <summary>
/// 用于在数据库上下文中调度和发布领域事件。
/// 目的是将在数据库上下文中发生的领域事件派发给相关的订阅者
/// 通过查询变更跟踪器并提取领域事件来实现此目的
/// 使用中介器（Mediator）将这些领域事件发布给相应的订阅者
/// 在发布前，还会清除已处理的领域事件，以确保每个事件只被处理一次。
/// 可以方便地在数据库上下文中调度和发布领域事件，将这些事件派发给相应的订阅者。
/// 这种方式遵循了 DDD 的原则，将数据持久化和领域事件处理解耦，提高了系统的可维护性和灵活性。
/// </summary>
public static class MediatorExtensions
{
    public static async Task DispatchDomainEventsAsync(this IMediator mediator, CompanyServerDbContext context)
    {
        var domainEntities = context.ChangeTracker
            .Entries<Entity>()
            .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any()).ToList();

        var domainEvents = domainEntities
            .SelectMany(x => x.Entity.DomainEvents)
            .ToList();

        if (domainEvents.Any())
        {
            domainEntities
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            var publishEventTasks = domainEvents.Select(e => mediator.Publish(e));
            await Task.WhenAll(publishEventTasks);
        }
    }
}