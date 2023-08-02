using CompanyServer.Core.Data;
using CompanyServer.Core.Domain.Companys;
using CompanyServer.Core.Domain.SeedWork;
using CompanyServer.Core.Domain.Warehouses;
using Microsoft.EntityFrameworkCore;

namespace CompanyServer.Core.Infrastructure.Domain.Warehouses;

public class WarehouseRepository : IWarehouseRepository
{
    public IUnitOfWork UnitOfWork => _dbContext;
    private readonly CompanyServerDbContext _dbContext;

    public WarehouseRepository(CompanyServerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Warehouse> GetByIdAsync(Guid id) =>
        await _dbContext.Warehouses.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);

    public async Task AddAsync(Warehouse warehouse) =>
        await _dbContext.Warehouses.AddAsync(warehouse).ConfigureAwait(false);

    public void Delete(Warehouse warehouse) => _dbContext.Warehouses.Remove(warehouse);
}