using Ardalis.Specification;
using CompanyServer.Core.Data;
using CompanyServer.Core.Domain.OrderItems;
using CompanyServer.Core.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace CompanyServer.Core.Infrastructure.Domain.OrderItems;

public class OrderItemRepository : IOrderItemRepository
{
    private readonly CompanyServerDbContext _context;

    public OrderItemRepository(CompanyServerDbContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;

    public async Task<OrderItem> GetById(Guid id) =>
        await _context.OrderItems.SingleAsync(x => x.Id == id).ConfigureAwait(false);

    public async Task<List<OrderItem>> ListAsync(ISpecification<OrderItem> specification) =>
        await specification.Apply(_context).ToListAsync().ConfigureAwait(false);

    public async Task<OrderItem> FindAsync(ISpecification<OrderItem> specification) =>
        await specification.Apply(_context).FirstOrDefaultAsync().ConfigureAwait(false);

    public void AddRange(IEnumerable<OrderItem> orderItems) => _context.OrderItems.AddRange(orderItems);

    public async Task AddAsync(OrderItem orderItem) =>
        await _context.OrderItems.AddAsync(orderItem).ConfigureAwait(false);

    public async Task<int> CountAsync(ISpecification<OrderItem> specification) =>
        await specification.Apply(_context).CountAsync().ConfigureAwait(false);
}