using Ardalis.Specification;
using CompanyServer.Core.Domain.SeedWork;

namespace CompanyServer.Core.Domain.OrderItems;

public interface IOrderItemRepository : IRepository<OrderItem>
{
    Task<OrderItem> GetById(Guid id);

    Task<List<OrderItem>> ListAsync(ISpecification<OrderItem> specification);

    Task<OrderItem> FindAsync(ISpecification<OrderItem> specification);

    void AddRange(IEnumerable<OrderItem> orderItems);

    Task AddAsync(OrderItem orderItem);

    Task<int> CountAsync(ISpecification<OrderItem> specification);
}