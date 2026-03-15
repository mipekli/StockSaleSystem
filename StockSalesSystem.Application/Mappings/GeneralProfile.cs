using AutoMapper;
using StockSalesSystem.Application.DTOs;
using StockSalesSystem.Application.Features.Categories.Commands;
using StockSalesSystem.Application.Features.Products.Commands;
using StockSalesSystem.Domain.Entities;

namespace StockSalesSystem.Application.Mappings;

public class GeneralProfile : Profile
{
    public GeneralProfile()
    {
        // Entity to DTO Maps
        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
            
        CreateMap<Category, CategoryDto>();

        // Command to Entity Maps
        CreateMap<CreateProductCommand, Product>();
        CreateMap<UpdateProductCommand, Product>();
        
        CreateMap<CreateCategoryCommand, Category>();
        CreateMap<UpdateCategoryCommand, Category>();
    }
}
