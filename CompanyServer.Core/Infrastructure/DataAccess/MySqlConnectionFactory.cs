using System.Data;
using CompanyServer.Core.Application.Configuration.Data;
using MySql.Data.MySqlClient;

namespace CompanyServer.Core.Infrastructure.DataAccess;

public class MySqlConnectionFactory : ISqlConnectionFactory
{
    private readonly string _connectionString;
    private IDbConnection _connection;

    public MySqlConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void Dispose()
    {
        if (_connection is { State: ConnectionState.Open })
        {
            _connection.Dispose();
        }
    }

    public IDbConnection GetOpenConnection()
    {
        if (_connection is not { State: ConnectionState.Open })
        {
            _connection = new MySqlConnection(_connectionString);
            _connection.Open();
        }

        return _connection;
    }

    public IDbConnection CreateNewConnection()
    {
        var connection = new MySqlConnection(_connectionString);
        connection.Open();

        return connection;
    }

    public string GetConnectionString()
    {
        return _connectionString;
    }
}