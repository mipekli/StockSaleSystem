using StockSalesSystem.Domain.Entities;

namespace StockSalesSystem.Application.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task AddAsync(T entity);
    Task<T?> GetByIdAsync(int id);
    Task<List<T>> GetAllAsync();
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}