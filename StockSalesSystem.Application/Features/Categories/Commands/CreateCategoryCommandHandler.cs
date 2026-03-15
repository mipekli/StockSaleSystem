using AutoMapper;
using MediatR;
using StockSalesSystem.Application.Interfaces;
using StockSalesSystem.Domain.Entities;

namespace StockSalesSystem.Application.Features.Categories.Commands;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
{
    private readonly IGenericRepository<Category> _repository;
    private readonly IMapper _mapper;

    public CreateCategoryCommandHandler(IGenericRepository<Category> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var categoryEntity = _mapper.Map<Category>(request);
        
        await _repository.AddAsync(categoryEntity);
        return categoryEntity.Id;
    }
}
