using System.Security.Principal;

namespace StockSalesSystem.Domain.Entities;

public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }
}