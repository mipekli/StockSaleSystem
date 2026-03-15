using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockSalesSystem.Application.DTOs;
using StockSalesSystem.Application.Features.Products.Commands;
using StockSalesSystem.Application.Features.Products.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockSalesSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductDto>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllProductsQuery());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetById(int id)
    {
        var result = await _mediator.Send(new GetProductByIdQuery(id));
        if (result == null) return NotFound("Ürün bulunamadı");
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateProductCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<bool>> Update(int id, [FromBody] UpdateProductCommand command)
    {
        if (id != command.Id) return BadRequest("URL ID'si ile Command ID'si uyuşmuyor.");
        
        var result = await _mediator.Send(command);
        if (!result) return NotFound("Güncellenmek istenen ürün bulunamadı.");
        
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteProductCommand(id));
        if (!result) return NotFound("Silinmek istenen ürün bulunamadı.");
        
        return Ok(result);
    }
}
