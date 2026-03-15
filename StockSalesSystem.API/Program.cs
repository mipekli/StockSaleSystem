using Microsoft.EntityFrameworkCore;
using StockSalesSystem.Infrastructure.Persistence;
using StockSalesSystem.Application;
using StockSalesSystem.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Clean Architecture Servis Kayıtları
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddControllers();

// CORS Ayarları (Angular Frontend için)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularUI", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // Angular'ın varsayılan portu
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Angular için eklenen Cors policynin aktif edilmesi (Mutlaka pipeline'da Controller'dan önce gelmeli)
app.UseCors("AllowAngularUI");

app.MapControllers();

app.Run();
