namespace CompanyServer.Core.Domain.Companys;

public interface ICompanyRepository
{
    Task<Company> GetByIdAsync(Guid id);
    Task AddAsync(Company company);
}