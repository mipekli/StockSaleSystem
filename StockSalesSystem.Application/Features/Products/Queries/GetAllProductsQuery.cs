using MediatR;
using StockSalesSystem.Application.DTOs;
using System.Collections.Generic;

namespace StockSalesSystem.Application.Features.Products.Queries;

public class GetAllProductsQuery : IRequest<List<ProductDto>>
{
    // Özel bir parametre alacaksa (sayfalama, filtreleme vb.) buraya eklenebilir.
}
