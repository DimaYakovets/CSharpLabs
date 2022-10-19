using Lab4.Models;
using Lab4.Services;

namespace Lab4.Controllers
{
    public sealed class PizzaController : GenericController<Pizza>
    {
        public PizzaController(IRepository<Pizza> repository)
            : base(repository)
        {

        }
    }
}