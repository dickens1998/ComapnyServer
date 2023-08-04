using CompanyServer.Core.Data;
using CompanyServer.Core.Domain.Companys;
using Microsoft.EntityFrameworkCore;

namespace CompanyServer.Core.Infrastructure.Domain.Companys;

public class CompanyRepository : ICompanyRepository
{
    private readonly CompanyServerDbContext _dbContext;

    public CompanyRepository(CompanyServerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Company> GetByIdAsync(Guid id) =>
        await _dbContext.Companies.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);

    public async Task AddAsync(Company company)
    {
        await _dbContext.Companies.AddAsync(company).ConfigureAwait(false);
        await _dbContext.SaveChangesAsync().ConfigureAwait(false);
    }

    public void DeleteAsync(Company company) => _dbContext.Companies.Remove(company);
}