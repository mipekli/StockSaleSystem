namespace StockSalesSystem.Domain.Entities;

public class Category : BaseEntity
{
    // required koyarak, nesne oluşturulurken bu alanın null geçilemeyeceğini ve 
    // derleyicinin verdiği uyarıyı kaldırdığımızı belirtiyoruz.
    public required string Name { get; set; }
    
    // Bire-Çok (One-to-Many) ilişki: Bir kategorinin birden fazla ürünü olabilir.
    public ICollection<Product> Products { get; set; } = new List<Product>();
}

// Bu bir Ara Tablo (Many-to-Many) veya bir varyasyonu için oluşturulmuş. 
// Navigation Property ekledik ki Entity Framework tablo bağlantılarını (Foreign Key) anlasın.
public class CategoryMap : BaseEntity
{
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
}