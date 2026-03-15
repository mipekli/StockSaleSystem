using AutoMapper;
using MediatR;
using StockSalesSystem.Application.Interfaces;
using StockSalesSystem.Domain.Entities;

namespace StockSalesSystem.Application.Features.Products.Commands;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IGenericRepository<Product> _repository;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(IGenericRepository<Product> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        // AutoMapper ile Command nesnesini Product entity'sine dönüştürüyoruz
        var productEntity = _mapper.Map<Product>(request);
        
        await _repository.AddAsync(productEntity);
        return productEntity.Id;
    }
}
