using System.Threading.Tasks;
using CompanyServer.Core.Application.OrderItems.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CompanyServer.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderItemController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderItemController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    ///  创建一个OrderItem
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateOrderItemCommand command)
    {
        await _mediator.Send(command);
        return Ok(new { Success = true, Message = "" });
    }

    /// <summary>
    /// OrderItem退货
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> ReturnSetWeightItem(ReturnSetWeightOrderItemCommand command)
    {
        await _mediator.Send(command);
        return Ok(new { Success = true, Message = "" });
    }
}