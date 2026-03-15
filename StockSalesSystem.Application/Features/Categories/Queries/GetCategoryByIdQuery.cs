using MediatR;
using StockSalesSystem.Application.DTOs;

namespace StockSalesSystem.Application.Features.Categories.Queries;

public class GetCategoryByIdQuery : IRequest<CategoryDto?>
{
    public int Id { get; set; }

    public GetCategoryByIdQuery(int id)
    {
        Id = id;
    }
}
