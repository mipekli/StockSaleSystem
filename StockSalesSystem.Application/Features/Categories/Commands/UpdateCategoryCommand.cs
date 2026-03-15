using MediatR;

namespace StockSalesSystem.Application.Features.Categories.Commands;

public class UpdateCategoryCommand : IRequest<bool>
{
    public int Id { get; set; }
    public required string Name { get; set; }
}
