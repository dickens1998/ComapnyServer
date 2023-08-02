using CompanyServer.Core.Application.Configuration;
using Microsoft.Extensions.Configuration;

namespace CompanyServer.Core.Settings;

public class MySqlConnectionString : IConfigurationSetting
{
    private readonly IConfiguration _configuration;

    public MySqlConnectionString(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string Value => _configuration.GetConnectionString("Mysql");
}