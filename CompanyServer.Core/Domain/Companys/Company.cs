namespace CompanyServer.Core.Domain.Companys;

/// <summary>
/// Id 属性表示 Company 的唯一标识，类型为 Guid。
/// Name、Email、Address、Phone 和 CreatedDate 这些属性具有私有的 setter，这意味着它们只能在构造函数中进行赋值，并且在对象创建后不能被外部更改。
/// </summary>
public class Company : IEntity
{
    public Guid Id { get;  set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Address { get; private set; }
    public string Phone { get; private set; }
    public DateTime CreatedDate { get; private set; }

    protected Company()
    {
    }

    /// <summary>
    /// 方法接受参数用于创建一个新的 Warehouse 对象，并将其关联到当前的 Company 对象。通过使用 Id 属性作为参数，新的 Warehouse 对象与当前 Company 对象建立了关联关系。
    /// </summary>
    /// <param name="name"></param>
    /// <param name="code"></param>
    /// <param name="address"></param>
    /// <param name="description"></param>
    /// <returns></returns>
    public Warehouse AddWarehouse(string name,
        string code,
        string address,
        string description)
    {
        return new Warehouse(Id, name, code, address, description);
    }

    /// <summary>
    /// 类有一个公共构造函数，接受 name、email、address 和 phone 参数，用于创建一个新的 Company 对象。在构造函数内部，为 Id 属性生成一个新的唯一标识，并为其他属性赋予传入的参数值。
    /// </summary>
    /// <param name="name"></param>
    /// <param name="email"></param>
    /// <param name="address"></param>
    /// <param name="phone"></param>
    public Company(string name, string email, string address, string phone)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        Address = address;
        Phone = phone;
        CreatedDate = DateTime.Now;
    }

    public static Company Create(string name, string email, string address, string phone)
    {
        return new Company(name, email, address, phone);
    }
}