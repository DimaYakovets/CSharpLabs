using Lab7.Models;

namespace Lab7.Client.Services
{
    public interface IGenericClient<TModel> where TModel : class, IModel
    {
        Task<TModel> CreateAsync(TModel model);
        Task DeleteAsync(int id);
        Task<IEnumerable<TModel>> GetAllAsync();
        Task<TModel> GetAsync(int id);
        Task<TModel> UpdateAsync(int id, TModel model);
    }
}