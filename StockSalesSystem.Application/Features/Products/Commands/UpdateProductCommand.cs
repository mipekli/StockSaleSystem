using MediatR;

namespace StockSalesSystem.Application.Features.Products.Commands;

public class UpdateProductCommand : IRequest<bool>
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }
}
