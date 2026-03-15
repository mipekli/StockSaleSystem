using AutoMapper;
using MediatR;
using StockSalesSystem.Application.DTOs;
using StockSalesSystem.Application.Interfaces;
using StockSalesSystem.Domain.Entities;

namespace StockSalesSystem.Application.Features.Products.Queries;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto?>
{
    private readonly IGenericRepository<Product> _repository;
    private readonly IMapper _mapper;

    public GetProductByIdQueryHandler(IGenericRepository<Product> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id);
        if (product == null) 
            return null;

        return _mapper.Map<ProductDto>(product);
    }
}
