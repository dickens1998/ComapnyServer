using MediatR;

namespace CompanyServer.Core.Domain.SeedWork;

public interface IDomainEvent : INotification
{
    Guid id { get; }
    DateTime OccurredOn { get; }
}