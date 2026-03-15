using StockSalesSystem.Domain.Entities;

namespace StockSalesSystem.Application.DTOs;

public class CategoryDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    
    // (Opsiyonel) Kategoriye bağlı ürünlerin listesini dönmek istersek
    public List<ProductDto> Products { get; set; } = new List<ProductDto>();
}
