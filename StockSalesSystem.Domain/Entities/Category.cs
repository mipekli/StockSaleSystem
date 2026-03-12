namespace StockSalesSystem.Domain.Entities;

public class Category :BaseEntity
{
    public string Name { get; set; }
    
}

public class CategoryMap:BaseEntity
{
    public int CategoryId { get; set; }
    public int ProductId { get; set; }
    
}