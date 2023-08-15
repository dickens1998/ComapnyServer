using Ardalis.GuardClauses;
using CompanyServer.Core.Domain.SeedWork;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CompanyServer.Core.Domain.ShareKernel;

public class UnitPrice : ValueObject
{
    public const string Lb = "LB";
    public const string Kg = "KG";

    private UnitPrice()
    {
    }

    private UnitPrice(decimal value, string unit)
    {
        Value = value;
        Unit = unit;
    }

    [JsonProperty] public decimal Value { get; private set; }

    [JsonProperty] public string Unit { get; private set; }

    [CanBeNull]
    public static UnitPrice Of(decimal value, string unit)
    {
        if (string.IsNullOrEmpty(unit)) return null;
        Guard.Against.NullOrEmpty(unit, nameof(value));

        return new UnitPrice(value, unit);
    }
}