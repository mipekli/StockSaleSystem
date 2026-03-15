using MediatR;
using StockSalesSystem.Application.Interfaces;
using StockSalesSystem.Domain.Entities;

namespace StockSalesSystem.Application.Features.Products.Commands;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IGenericRepository<Product> _repository;

    public DeleteProductCommandHandler(IGenericRepository<Product> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var existingProduct = await _repository.GetByIdAsync(request.Id);
        
        if (existingProduct == null) 
            return false;

        await _repository.DeleteAsync(existingProduct);
        return true;
    }
}
