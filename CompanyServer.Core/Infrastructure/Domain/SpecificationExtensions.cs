using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using CompanyServer.Core.Data;
using CompanyServer.Core.Domain.SeedWork;

namespace CompanyServer.Core.Infrastructure.Domain;

/// <summary>
/// 可以在使用 Entity Framework Core 进行数据库查询时，方便地应用规约来限制查询结果的条件。
/// 这种方式遵循了 DDD 中的规约模式，可以将特定的查询逻辑封装到规约对象中，提高代码的可维护性和可重用性。
/// </summary>
public static class SpecificationExtensions
{
    public static IQueryable<T> Apply<T>(this ISpecification<T> spec, CompanyServerDbContext context) where T : Entity
    {
        var evaluator = new SpecificationEvaluator();
        //用 evaluator.GetQuery 方法，传入规约和查询对象（context.Set<T>().AsQueryable()），返回已经应用规约的查询结果。
        return evaluator.GetQuery(context.Set<T>().AsQueryable(), spec);
    }
}