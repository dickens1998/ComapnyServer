using CompanyServer.Core.Domain.SeedWork;
using CompanyServer.Message.Enums;

namespace CompanyServer.Core.Domain.Companys;

public class Warehouse : IEntity, IAggregateRoot
{
    public Guid Id { get; set; }
    public Guid CompanyId { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public WarehouseStatus Status { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdateDate { get; set; }

    protected Warehouse()
    {
    }

    public Warehouse(Guid companyId, string name, string code, string address, string description)
    {
        CompanyId = companyId;
        Name = name;
        Code = code;
        Address = address;
        Description = description;
        CreatedDate = DateTime.Now;
        UpdateDate = DateTime.Now;
        Status = WarehouseStatus.Active;
    }
    
    
}