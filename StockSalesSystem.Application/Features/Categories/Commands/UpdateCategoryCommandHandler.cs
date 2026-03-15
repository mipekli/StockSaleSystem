using MediatR;
using StockSalesSystem.Application.Interfaces;
using StockSalesSystem.Domain.Entities;

namespace StockSalesSystem.Application.Features.Categories.Commands;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
{
    private readonly IGenericRepository<Category> _repository;

    public UpdateCategoryCommandHandler(IGenericRepository<Category> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var existingCategory = await _repository.GetByIdAsync(request.Id);
        
        if (existingCategory == null) 
            return false;

        existingCategory.Name = request.Name;

        await _repository.UpdateAsync(existingCategory);
        return true;
    }
}
