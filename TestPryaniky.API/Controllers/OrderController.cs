using TestPryaniky.Application.Orders.Commands;
using TestPryaniky.Application.Orders.Queries;

namespace TestPryaniky.API.Controllers;

[ApiController]
[Route("api/v1/orders")]
public class OrderController(ISender sender)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderCommand command)
    {
        var result = await sender.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = result.Id}, result);
    }
    
    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await sender.Send(new DeleteOrderCommand(id));

        return Ok(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateOrderCommand command)
    {
        var result = await sender.Send(command);

        return Ok(result);
    }
    
    [HttpPatch]
    public async Task<IActionResult> UpdateStatus([AsParameters] UpdateOrderStatusCommand command)
    {
        var result = await sender.Send(command);

        return Ok(result);
    }
    
    [HttpDelete]
    [Route("items")]
    public async Task<IActionResult> UpdateStatus([FromBody] DeleteItemsFromOrderCommand command)
    {
        var result = await sender.Send(command);

        return Ok(result);
    }
    
    [HttpPut]
    [Route("items")]
    public async Task<IActionResult> UpdateStatus([FromBody] AddItemsToOrderCommand command)
    {
        var result = await sender.Send(command);

        return Ok(result);
    }
    
    [HttpGet]
    [Route("page")]
    public async Task<IActionResult> GetPaginated(int pageIndex = 0, int pageSize = 10)
    {
        var query = new GetOrdersPaginatedQuery(new PaginationRequest(pageIndex, pageSize));

        var result = await sender.Send(query);

        return Ok(result);
    }
    
    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetOrderByIdQuery(id);

        var result = await sender.Send(query);

        return Ok(result);
    }
    
    [HttpGet]
    [Route("{status}")]
    public async Task<IActionResult> GetByName(OrderStatus status)
    {
        var query = new GetOrdersByStatusQuery(status);

        var result = await sender.Send(query);

        return Ok(result);
    }
}