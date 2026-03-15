using MediatR;
using StockSalesSystem.Application.DTOs;

namespace StockSalesSystem.Application.Features.Products.Commands;

public class CreateProductCommand : IRequest<int>
{
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }
}
