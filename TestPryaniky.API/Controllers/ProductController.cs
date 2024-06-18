using TestPryaniky.Application.Products.Commands;
using TestPryaniky.Application.Products.Queries;

namespace TestPryaniky.API.Controllers;

[ApiController]
[Route("api/v1/products")]
public class ProductController(ISender sender)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
    {
        var result = await sender.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = result.Id}, result);
    }
    
    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await sender.Send(new DeleteProductCommand(id));

        return Ok(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProductCommand command)
    {
        var result = await sender.Send(command);

        return Ok(result);
    }

    [HttpGet]
    [Route("page")]
    public async Task<IActionResult> GetPaginated(int pageIndex = 0, int pageSize = 10)
    {
        var query = new GetProductsPaginatedQuery(new PaginationRequest(pageIndex, pageSize));

        var result = await sender.Send(query);

        return Ok(result);
    }
    
    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetProductByIdQuery(id);

        var result = await sender.Send(query);

        return Ok(result);
    }
    
    [HttpGet]
    [Route("{name}")]
    public async Task<IActionResult> GetByName(string name)
    {
        var query = new GetProductByNameQuery(name);

        var result = await sender.Send(query);

        return Ok(result);
    }
}