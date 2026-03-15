using AutoMapper;
using MediatR;
using StockSalesSystem.Application.Interfaces;
using StockSalesSystem.Domain.Entities;

namespace StockSalesSystem.Application.Features.Products.Commands;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly IGenericRepository<Product> _repository;

    public UpdateProductCommandHandler(IGenericRepository<Product> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var existingProduct = await _repository.GetByIdAsync(request.Id);
        
        if (existingProduct == null) 
            return false;

        existingProduct.Name = request.Name;
        existingProduct.Price = request.Price;
        existingProduct.Stock = request.Stock;
        existingProduct.CategoryId = request.CategoryId;

        await _repository.UpdateAsync(existingProduct);
        return true;
    }
}
