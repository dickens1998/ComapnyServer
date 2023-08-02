using Autofac;
using CompanyServer.Core.Application.Configuration;
using CompanyServer.Core.Data;
using CompanyServer.Core.Infrastructure.DataAccess;
using CompanyServer.Core.Infrastructure.Domain;
using CompanyServer.Core.Infrastructure.Mediator;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace CompanyServer.Core;

public class CompanyServerModule : Module
{
    private readonly string _seqAddress;
    private readonly string _connectionString;

    public CompanyServerModule(string seqAddress, string connectionString)
    {
        _seqAddress = seqAddress;
        _connectionString = connectionString;
    }

    protected override void Load(ContainerBuilder builder)
    {
        RegisterSettings(builder);
        RegisterDatabase(builder);
        RegisterLogger(builder);

        builder.RegisterModule(new DataAccessModule(_connectionString));
        builder.RegisterModule(new MediatorModule());
        builder.RegisterModule(new DomainModule());
    }

    private static void RegisterDatabase(ContainerBuilder builder)
    {
        builder.RegisterType<CompanyServerDbContext>()
            .AsSelf()
            .As<DbContext>()
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
    }

    private static void RegisterSettings(ContainerBuilder builder)
    {
        builder.RegisterTypes(typeof(CompanyServerModule).Assembly.GetTypes()
                .Where(x => x.IsClass && typeof(IConfigurationSetting).IsAssignableFrom(x)).ToArray()).AsSelf()
            .SingleInstance();
    }

    private void RegisterLogger(ContainerBuilder builder)
    {
        builder.Register<ILogger>((c, p) => new LoggerConfiguration().WriteTo.Seq(_seqAddress)
            .CreateLogger()).SingleInstance();
    }
}