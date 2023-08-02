using Autofac;
using CompanyServer.Core.Application.Configuration.Data;

namespace CompanyServer.Core.Infrastructure.DataAccess;

public class DataAccessModule : Module
{
    private readonly string _connectionString;

    public DataAccessModule(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<MySqlConnectionFactory>()
            .WithParameter("connectionString", _connectionString)
            .As<ISqlConnectionFactory>();
    }
}