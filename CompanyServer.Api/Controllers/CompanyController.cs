using System;
using System.Threading.Tasks;
using CompanyServer.Core.Application.Companys;
using CompanyServer.Core.Application.Warehouses.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CompanyServer.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyController : ControllerBase
{
    private readonly IMediator _mediator;

    public CompanyController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreatedAsync([FromBody] AddCompanyCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(new { Success = true, Message = "", Data = result });
    }

    [HttpPost("addWarehouse")]
    public async Task<IActionResult> AddCompanyWarehouseAsync([FromBody] AddWarehouseCommand command)
    {
        await _mediator.Send(command);
        return Ok(new { Success = true, Message = "" });
    }

    [HttpDelete("{warehouseId:Guid}/deleteCompanyWarehouse")]
    public async Task<IActionResult> DeleteCompanyWarehouseAsync(Guid warehouseId)
    {
        var result = await _mediator.Send(new DeleteWarehouseCommand(warehouseId));
        return Ok(new { Success = result, Message = "" });
    }
}