using MediatR;
using StockSalesSystem.Application.DTOs;

namespace StockSalesSystem.Application.Features.Categories.Queries;

public class GetAllCategoriesQuery : IRequest<List<CategoryDto>>
{
}
