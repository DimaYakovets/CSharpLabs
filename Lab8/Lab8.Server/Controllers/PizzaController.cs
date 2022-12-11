using Lab8.Models;
using Lab8.Services;

namespace Lab8.Controllers
{
    public sealed class PizzaController : GenericController<Pizza>
    {
        public PizzaController(IRepository<Pizza> repository)
            : base(repository)
        {

        }
    }
}