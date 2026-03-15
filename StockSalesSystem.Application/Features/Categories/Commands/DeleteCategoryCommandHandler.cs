using MediatR;
using StockSalesSystem.Application.Interfaces;
using StockSalesSystem.Domain.Entities;

namespace StockSalesSystem.Application.Features.Categories.Commands;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
{
    private readonly IGenericRepository<Category> _repository;

    public DeleteCategoryCommandHandler(IGenericRepository<Category> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var existingCategory = await _repository.GetByIdAsync(request.Id);
        
        if (existingCategory == null) 
            return false;

        await _repository.DeleteAsync(existingCategory);
        return true;
    }
}
