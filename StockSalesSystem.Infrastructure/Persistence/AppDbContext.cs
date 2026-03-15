using Microsoft.EntityFrameworkCore;
using StockSalesSystem.Domain.Entities;

namespace StockSalesSystem.Infrastructure.Persistence;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products  { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<CategoryMap> CategoryMaps  { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Price için Warning'i çözme
        modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasColumnType("decimal(18,2)");

        // Kategori altındaki ürün silinirken kaskad silmeyi durdurma
        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        // CategoryMap içindeki Product ilişkisi
        modelBuilder.Entity<CategoryMap>()
            .HasOne(cm => cm.Product)
            .WithMany()
            .HasForeignKey(cm => cm.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        // CategoryMap içindeki Category ilişkisi
        modelBuilder.Entity<CategoryMap>()
            .HasOne(cm => cm.Category)
            .WithMany()
            .HasForeignKey(cm => cm.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}