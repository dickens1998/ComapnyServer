using CompanyServer.Core.Data;
using CompanyServer.Core.Domain.SeedWork;
using MediatR;

namespace CompanyServer.Core.Infrastructure.Domain;

/// <summary>
/// 用于调度和处理领域事件。
/// 实现了一个领域事件调度器
/// 它通过跟踪数据库上下文中的实体，获取它们的领域事件并进行处理。
/// 这样可以提供一种集中处理领域事件的机制，使得领域模型和应用程序其他部分之间的解耦更加清晰和可维护。
/// </summary>
public class DomainEventsDispatcher : IDomainEventsDispatcher
{
    private readonly CompanyServerDbContext _context;
    private readonly IMediator _mediator;

    public DomainEventsDispatcher(CompanyServerDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task DispatchEventsAsync()
    {
        //  获取所有被跟踪的实体（派生自基类 Entity），然后筛选出具有未处理领域事件的实体。
        var domainEntities = _context.ChangeTracker
            .Entries<Entity>()
            .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any()).ToList();

        //领域事件扁平化为一个统一的领域事件列表。
        var domainEvents = domainEntities
            .SelectMany(x => x.Entity.DomainEvents)
            .ToList();

        // 调用每个实体的 ClearDomainEvents 方法清除已处理的领域事件。
        domainEntities.ForEach(entity => entity.Entity.ClearDomainEvents());

        // 调用 _mediator.Publish 方法将每个领域事件发布给中介者进行处理。
        var tasks = domainEvents
            .Select(@event => _mediator.Publish(@event));

        //所有发布领域事件的任务完成。
        await Task.WhenAll(tasks);
    }
}