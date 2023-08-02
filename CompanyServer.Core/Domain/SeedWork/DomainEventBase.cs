namespace CompanyServer.Core.Domain.SeedWork;

public class DomainEventBase : IDomainEvent
{
    public DomainEventBase()
    {
        id = Guid.NewGuid();
        OccurredOn = DateTime.Now;
    }

    public Guid id { get; }
    public DateTime OccurredOn { get; }
}