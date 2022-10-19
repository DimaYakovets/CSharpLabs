using Lab4.Models;
using Lab4.Services;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace Lab4.Controllers
{
    public abstract class GenericController<TModel> : Controller
        where TModel : class, IModel
    {
        private readonly IRepository<TModel> _repository;

        public GenericController(IRepository<TModel> repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetAllAsync());
        }
        public async Task<IActionResult> Add()
        {
            return await Task.FromResult(View());
        }
        public async Task<IActionResult> Details(int id)
        {
            TModel model = await _repository.GetAsync(id);

            return View(model);
        }
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _repository.GetAsync(id));
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);

            return Redirect("../Index");
        }

        public async Task<IActionResult> Create(TModel model)
        {
            await _repository.CreateAsync(model);

            return Redirect("Index");
        }
        public async Task<IActionResult> Update(TModel model)
        {
            await _repository.UpdateAsync(model.Id, model);

            return Redirect("Index");
        }
    }
}
