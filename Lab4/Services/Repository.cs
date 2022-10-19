using Lab4.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab4.Services
{
    public sealed class Repository<TModel> : IRepository<TModel>
        where TModel : class, IModel
    {
        private readonly PizzaDeliveryContext _context;

        public Repository(PizzaDeliveryContext context)
        {
            _context = context;
        }

        public async Task<TModel> CreateAsync(TModel entity)
        {
            var result = _context.Set<TModel>().Add(entity);

            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            TModel result = await _context.Set<TModel>().FirstAsync(e => e.Id == id);

            _context.Set<TModel>().Remove(result);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TModel>> GetAllAsync()
        {
            return await _context.Set<TModel>().ToListAsync();
        }

        public async Task<TModel> GetAsync(int id)
        {
            return await _context.Set<TModel>().FirstAsync(e => e.Id == id);
        }

        public async Task<TModel> UpdateAsync(int id, TModel entity)
        {
            entity.Id = id;

            var result = _context.Set<TModel>().Update(entity);

            await _context.SaveChangesAsync();

            return result.Entity;
        }
    }
}
