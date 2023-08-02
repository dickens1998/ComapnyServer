using CompanyServer.Core.Application.Configuration.Commands;

namespace CompanyServer.Core.Application.Companys;

public class AddCompanyCommand : ICommand<Guid>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
}