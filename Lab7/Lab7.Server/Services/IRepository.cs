using Lab7.Models;

namespace Lab7.Client.Services;

public interface IRepository<T>
    where T : class, IModel
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetAsync(int id);
    Task<T> CreateAsync(T entity);
    Task DeleteAsync(int id);
    Task<T> UpdateAsync(int id, T entity);
}
