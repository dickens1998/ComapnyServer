using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using CompanyServer.Core.Data;
using CompanyServer.Core.Domain.SeedWork;

namespace CompanyServer.Core.Infrastructure.Domain;

public static class SpecificationExtensions
{
    public static IQueryable<T> Apply<T>(this ISpecification<T> spec, CompanyServerDbContext context) where T : Entity
    {
        var evaluator = new SpecificationEvaluator();
        return evaluator.GetQuery(context.Set<T>().AsQueryable(), spec);
    }
}