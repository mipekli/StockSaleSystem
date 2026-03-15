using AutoMapper;
using MediatR;
using StockSalesSystem.Application.DTOs;
using StockSalesSystem.Application.Interfaces;
using StockSalesSystem.Domain.Entities;

namespace StockSalesSystem.Application.Features.Categories.Queries;

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto?>
{
    private readonly IGenericRepository<Category> _repository;
    private readonly IMapper _mapper;

    public GetCategoryByIdQueryHandler(IGenericRepository<Category> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CategoryDto?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _repository.GetByIdAsync(request.Id);
        if (category == null) 
            return null;

        return _mapper.Map<CategoryDto>(category);
    }
}
