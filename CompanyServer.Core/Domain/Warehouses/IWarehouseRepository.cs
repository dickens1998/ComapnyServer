using CompanyServer.Core.Domain.Companys;
using CompanyServer.Core.Domain.SeedWork;

namespace CompanyServer.Core.Domain.Warehouses;

public interface IWarehouseRepository : IRepository<Warehouse>
{
    Task<Warehouse> GetByIdAsync(Guid id);
    Task AddAsync(Warehouse warehouse);
    void Delete(Warehouse warehouse);
}