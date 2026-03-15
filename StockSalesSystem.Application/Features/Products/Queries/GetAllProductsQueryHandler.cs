using AutoMapper;
using MediatR;
using StockSalesSystem.Application.DTOs;
using StockSalesSystem.Application.Interfaces;
using StockSalesSystem.Domain.Entities;

namespace StockSalesSystem.Application.Features.Products.Queries;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
{
    private readonly IGenericRepository<Product> _repository;
    private readonly IMapper _mapper;

    public GetAllProductsQueryHandler(IGenericRepository<Product> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _repository.GetAllAsync(); // Normalde Includes(p => p.Category) gerekecek
        return _mapper.Map<List<ProductDto>>(products);
    }
}
