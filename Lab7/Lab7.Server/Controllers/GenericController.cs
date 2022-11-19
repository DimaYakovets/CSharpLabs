using Lab7.Models;
using Lab7.Client.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class GenericController<TModel> : ControllerBase
        where TModel : class, IModel
    {
        private readonly IRepository<TModel> _repository;

        public GenericController(IRepository<TModel> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<TModel>> Get()
        {
            return await _repository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<TModel> Get(int id)
        {
            return await _repository.GetAsync(id);
        }

        [HttpPost]
        public async Task<TModel> Post([FromBody] TModel entity)
        {
            return await _repository.CreateAsync(entity);
        }

        [HttpPut("{id}")]
        public async Task<TModel> PutAsync(int id, [FromBody] TModel entity)
        {
            return await _repository.UpdateAsync(id, entity);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
