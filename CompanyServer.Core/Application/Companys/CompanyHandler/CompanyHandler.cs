using CompanyServer.Core.Domain.Companys;
using MediatR;

namespace CompanyServer.Core.Application.Companys.CompanyHandler;

public class CompanyHandler : IRequestHandler<AddCompanyCommand, Guid>
{
    private readonly ICompanyRepository _companyRepository;

    public CompanyHandler(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public async Task<Guid> Handle(AddCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = new Company(request.Name, request.Email, request.Address, request.Phone);
        await _companyRepository.AddAsync(company);
        return company.Id;
    }
}