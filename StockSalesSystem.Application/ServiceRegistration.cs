using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace StockSalesSystem.Application;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        // AutoMapper'ı otomatik olarak tüm proje (bulunduğu Assembly) üzerinden okuyup kaydeder.
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        // MediatR 12.0+ sonrası yeni kayıt tarzı. Uygulama içerisindeki tüm Handler komutlarını otomatik bulur.
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}
