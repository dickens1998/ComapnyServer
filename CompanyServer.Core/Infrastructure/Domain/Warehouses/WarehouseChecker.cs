using CompanyServer.Core.Application.Configuration.Data;
using CompanyServer.Core.Domain.Warehouses;
using Dapper;

namespace CompanyServer.Core.Infrastructure.Domain.Warehouses;

public class WarehouseChecker : IWarehouseChecker
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public WarehouseChecker(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public bool IsUniqueWithName(Guid companyId, string name)
    {
        var connection = _sqlConnectionFactory.GetOpenConnection();

        const string sql = @"SELECT COUNT(1)
                                    FROM `warehouse`
                                    WHERE `company_id` = @companyId
                                    AND `name`  = @name";

        return connection.QuerySingle<int>(sql, new { companyId, name }) == 0;
    }

    public int CalculateWarehouseUsers(Guid warehouseId)
    {
        var connection = _sqlConnectionFactory.GetOpenConnection();

        const string sql = @"SELECT COUNT(*) 
                                    FROM `warehouse_users` 
                                    LEFT JOIN `warehouse` 
                                    ON `warehouse_users`.`warehouse_id` = `warehouse`.`id` 
                                    WHERE `warehouse`.`id` = @warehouseId";

        return connection.QuerySingle<int>(sql, new { warehouseId });
    }
}