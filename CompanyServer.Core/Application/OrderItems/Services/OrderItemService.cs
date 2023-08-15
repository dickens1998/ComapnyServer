using CompanyServer.Core.Application.Configuration.Exceptions;
using CompanyServer.Core.Application.OrderItems.Commands;
using CompanyServer.Core.Data;
using CompanyServer.Core.Domain.OrderItems;
using Microsoft.EntityFrameworkCore;

namespace CompanyServer.Core.Application.OrderItems.Services;

public class OrderItemService : IOrderItemService
{
    private readonly CompanyServerDbContext _context;

    public OrderItemService(CompanyServerDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(CreateOrderItemCommand command)
    {
        var orderItem = OrderItem.Create(command.Material, command.Weight, command.CompanyId, command.WarehouseId);
        await _context.OrderItems.AddAsync(orderItem).ConfigureAwait(false);
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task ReturnOrderItemAsync(ReturnSetWeightOrderItemCommand command)
    {
        var orderItem = await _context.OrderItems.Include(x => x.GoodsList)
            .FirstOrDefaultAsync(x => x.Id == command.OrderItemId)
            .ConfigureAwait(false);

        if (orderItem == null) throw new NotFoundException(nameof(OrderItem), command.OrderItemId);

        orderItem.AddGoods(command.ReturnWeight);
    }
}