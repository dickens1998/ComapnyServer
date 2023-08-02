using System.Reflection;
using Autofac;
using CompanyServer.Core.Application.Configuration.Behaviours;
using CompanyServer.Core.Application.Warehouses.Commands;
using MediatR;
using MediatR.Pipeline;
using Module = Autofac.Module;

namespace CompanyServer.Core.Infrastructure.Mediator;

public class MediatorModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
            .AsImplementedInterfaces();

        builder.RegisterAssemblyTypes(typeof(AddWarehouseCommand).GetTypeInfo().Assembly)
            .AsClosedTypesOf(typeof(IRequestHandler<,>));


        builder.RegisterGeneric(typeof(LoggingBehaviour<>)).As(typeof(IRequestPreProcessor<>));
    }
}