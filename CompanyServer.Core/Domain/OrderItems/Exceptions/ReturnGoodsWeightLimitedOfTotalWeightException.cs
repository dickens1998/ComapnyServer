using CompanyServer.Core.Domain.ShareKernel;

namespace CompanyServer.Core.Domain.OrderItems.Exceptions;

public class ReturnGoodsWeightLimitedOfTotalWeightException : Exception
{
    public ReturnGoodsWeightLimitedOfTotalWeightException(Weight returnWeight, Weight totalWeight)
        : base($"Return weight out of limit(Return weight:{returnWeight},Total weight:{totalWeight})")
    {
    }
}