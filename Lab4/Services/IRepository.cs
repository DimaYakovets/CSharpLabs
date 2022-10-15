using Lab4.Models;

namespace Lab4.Services;

public interface IRepository<T>
    where T : class, IModel
{
    Task<IEnumerable<T>> GetAllAsync(T entity);
    Task<T> GetAsync(int id);
    Task<T> CreateAsync(T entity);
    Task DeleteAsync(int id);
    Task<T> UpdateAsync(int id, T entity);
}
