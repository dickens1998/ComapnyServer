using Ardalis.Specification;

namespace CompanyServer.Core.Domain.SeedWork;

public interface IAsyncRepository<T> where T : Entity
{
    Task<T> GetByIdAsync(Guid id);
    Task<IReadOnlyList<T>> ListAllAsync();
    Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<T> AddAllAsync(IEnumerable<T> entity);
    Task UpdateAllAsync(IEnumerable<T> entity);
    Task<int> CountAsync(ISpecification<T> spec);
    Task<T> FirstAsync(ISpecification<T> spec);
    Task<T> FirstOrDefaultAsync(ISpecification<T> spec);
}