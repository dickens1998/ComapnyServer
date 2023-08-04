namespace CompanyServer.Core.Domain.SeedWork;

public class DomainEventBase : IDomainEvent
{
    public DomainEventBase()
    {
        Id = Guid.NewGuid();
        OccurredOn = DateTime.Now;
    }

    public Guid Id { get; }
    public DateTime OccurredOn { get; }
}