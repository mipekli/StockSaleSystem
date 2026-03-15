using MediatR;

namespace StockSalesSystem.Application.Features.Categories.Commands;

public class CreateCategoryCommand : IRequest<int>
{
    public required string Name { get; set; }
}
