using CompanyServer.Core.Domain.SeedWork;

namespace CompanyServer.Core.Domain.ShareKernel;

public class Material : ValueObject
{
    private Material()
    {
    }

    private Material(string number, string description, string qcType)
    {
        Number = number;
        Description = description;
        QcType = qcType;
    }

    public string QcType { get; set; }

    public string Description { get; set; }

    public string Number { get; set; }

    public static Material Of(string number, string description, string qcType)
    {
        return new Material(number, description, qcType);
    }
}