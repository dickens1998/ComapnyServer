namespace CompanyServer.Core.Domain.SeedWork;

public interface IDomainEventsDispatcher
{
    Task DispatchEventsAsync();
}