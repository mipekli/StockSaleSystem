using Microsoft.Extensions.DependencyInjection;
using StockSalesSystem.Application.Interfaces;
using StockSalesSystem.Infrastructure.Repositories;

namespace StockSalesSystem.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        // Generic Repository Pattern kaydı
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        
        // Diğer veritabanı spesifik servisler (UnitOfWork, FileStorage vb.) buraya eklenebilir.
    }
}
