using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockSalesSystem.Application.DTOs;
using StockSalesSystem.Application.Features.Categories.Commands;
using StockSalesSystem.Application.Features.Categories.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockSalesSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<CategoryDto>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllCategoriesQuery());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDto>> GetById(int id)
    {
        var result = await _mediator.Send(new GetCategoryByIdQuery(id));
        if (result == null) return NotFound("Kategori bulunamadı");
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateCategoryCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<bool>> Update(int id, [FromBody] UpdateCategoryCommand command)
    {
        if (id != command.Id) return BadRequest("URL ID'si ile Command ID'si uyuşmuyor.");
        
        var result = await _mediator.Send(command);
        if (!result) return NotFound("Güncellenmek istenen kategori bulunamadı.");
        
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteCategoryCommand(id));
        if (!result) return NotFound("Silinmek istenen kategori bulunamadı.");
        
        return Ok(result);
    }
}
