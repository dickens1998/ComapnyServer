using System.Reflection;
using Autofac;
using CompanyServer.Core.Application.Configuration.Behaviours;
using CompanyServer.Core.Application.Warehouses.Commands;
using MediatR;
using MediatR.Pipeline;
using Module = Autofac.Module;

namespace CompanyServer.Core.Infrastructure.Mediator;

/// <summary>
/// 将中介者相关的类型和行为注入到 Autofac 容器中，
/// 使得中介者及其相关功能可以在应用程序中进行依赖注入，并且实现了请求处理程序的自动注册
/// </summary>
public class MediatorModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        //使用 RegisterAssemblyTypes 方法将 IMediator 接口所在程序集中的所有类型都注册为其实现的接口。
        builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
            .AsImplementedInterfaces();

        //用 RegisterAssemblyTypes 方法将 AddWarehouseCommand 类所在程序集中所有闭合类型为 IRequestHandler<,> 的类型注册到容器。
        //这样做的目的是将命令处理程序注册为对应的请求处理程序。
        builder.RegisterAssemblyTypes(typeof(AddWarehouseCommand).GetTypeInfo().Assembly)
            .AsClosedTypesOf(typeof(IRequestHandler<,>));

        //使用 RegisterGeneric 方法注册一个泛型类型 LoggingBehaviour<>，它实现了 IRequestPreProcessor<> 接口。
        //这个行为会在请求处理前执行，用于记录日志等预处理操作。
        builder.RegisterGeneric(typeof(LoggingBehaviour<>)).As(typeof(IRequestPreProcessor<>));
    }
}