using CompanyServer.Core.Data;
using CompanyServer.Core.Domain.SeedWork;
using MediatR;

namespace CompanyServer.Core.Infrastructure.Mediator;

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