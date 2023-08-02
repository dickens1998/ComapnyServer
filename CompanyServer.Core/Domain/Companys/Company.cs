namespace CompanyServer.Core.Domain.Companys;

public class Company : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public DateTime CreatedDate { get; set; }

    protected Company()
    {
    }

    public Warehouse AddWarehouse(string name,
        string code,
        string address,
        string description)
    {
        return new Warehouse(Id, name, code, address, description);
    }

    public Company(string name, string email, string address, string phone)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        Address = address;
        Phone = phone;
        CreatedDate = DateTime.Now;
    }
}