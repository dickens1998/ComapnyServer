using Autofac;
using CompanyServer.Core.Domain.SeedWork;
using CompanyServer.Core.Domain.Warehouses;
using CompanyServer.Core.Infrastructure.Domain.Warehouses;

namespace CompanyServer.Core.Infrastructure.Domain;

public class DomainModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<DomainEventsDispatcher>()
            .As<IDomainEventsDispatcher>()
            .InstancePerLifetimeScope();

        builder.RegisterAssemblyTypes(typeof(DomainModule).Assembly)
            .Where(type => type.Name.EndsWith("Repository"))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();

        builder.RegisterType<WarehouseChecker>()
            .As<IWarehouseChecker>();
    }
}