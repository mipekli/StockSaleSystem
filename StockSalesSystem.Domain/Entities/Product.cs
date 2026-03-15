namespace StockSalesSystem.Domain.Entities;

public class Product : BaseEntity
{
    // required anahtar kelimesi ile boş geçilemeyecek string (veritabanında null olamaz)
    public required string Name { get; set; }
    
    public decimal Price { get; set; }
    public int Stock { get; set; }
    
    // Foreign Key (Veritabanında Category tablosuyla ilişki kuracak kolon).
    // Int değerler referans tipli olmadığı için zaten "null olamaz"dır.
    public int CategoryId { get; set; }

    // Navigation Property: EF Core için ilişkili Kategori objesini tutar
    public Category Category { get; set; } = null!;
}