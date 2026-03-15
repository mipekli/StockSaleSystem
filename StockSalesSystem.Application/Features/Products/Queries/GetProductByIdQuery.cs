using AutoMapper;
using MediatR;
using StockSalesSystem.Application.DTOs;
using StockSalesSystem.Application.Interfaces;

namespace StockSalesSystem.Application.Features.Products.Queries;

public class GetProductByIdQuery : IRequest<ProductDto?>
{
    public int Id { get; set; }

    public GetProductByIdQuery(int id)
    {
        Id = id;
    }
}
