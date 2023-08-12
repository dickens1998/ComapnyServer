using CompanyServer.Core.Domain.Companys;

namespace CompanyServer.UnitTetst.Domain;

public static class CompanyProvider
{
    public static Company CreateCompany(string name, string email, string address, string phone)
    {
        return Company.Create(name, email, address, phone);
    }
}