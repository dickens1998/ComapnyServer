using Ardalis.GuardClauses;
using CompanyServer.Core.Domain.SeedWork;
using Newtonsoft.Json;

namespace CompanyServer.Core.Domain.ShareKernel;

public class Weight : ValueObject
{
    public static string Lb = nameof(Lb);
    public static string Kg = nameof(Kg);

    private Weight()
    {
    }

    public Weight(decimal value, string unit)
    {
        Guard.Against.Negative(value, nameof(value));

        Value = value;
        Unit = unit;
    }

    [JsonProperty] public decimal Value { get; private set; }

    [JsonProperty] public string Unit { get; private set; }
    
    public static Weight Of(decimal value, string unit)
    {
        return string.Equals(unit, Lb, StringComparison.CurrentCultureIgnoreCase) ? OfLb(value) : OfKg(value);
    }

    public static Weight OfLb(decimal value)
    {
        return new Weight(value, Lb);
    }

    public static Weight OfKg(decimal value)
    {
        return new Weight(value, Kg);
    }
    
    public override string ToString()
    {
        return $"{Value}{Unit}";
    }

    private Weight ToLb()
    {
        if (Unit != Kg) return this;

        var value = decimal.Round(Value * 2.20462262185m, 2);
        return OfLb(value);
    }
    
    public Weight ToKg()
    {
        if (Unit != Lb) return this;

        var value = decimal.Round(Value * 0.4535924m, 2);
        return OfKg(value);
    }

    
    public static bool operator >(Weight w1, Weight w2)
    {
        return w1.ToLb().Value > w2.ToLb().Value;
    }

    public static bool operator <(Weight w1, Weight w2)
    {
        return w1.ToLb().Value < w2.ToLb().Value;
    }
}