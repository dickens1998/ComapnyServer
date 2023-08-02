using System.Data;

namespace CompanyServer.Core.Application.Configuration.Data;

public interface ISqlConnectionFactory : IDisposable
{
    IDbConnection GetOpenConnection();

    IDbConnection CreateNewConnection();

    string GetConnectionString();
}