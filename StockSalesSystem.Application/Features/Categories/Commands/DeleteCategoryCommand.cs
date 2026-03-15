using MediatR;

namespace StockSalesSystem.Application.Features.Categories.Commands;

public class DeleteCategoryCommand : IRequest<bool>
{
    public int Id { get; set; }

    public DeleteCategoryCommand(int id)
    {
        Id = id;
    }
}
