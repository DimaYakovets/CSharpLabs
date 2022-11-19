using Lab7.Models;
using Lab7.Client.Services;

namespace Lab7.Controllers
{
    public sealed class PizzaController : GenericController<Pizza>
    {
        public PizzaController(IRepository<Pizza> repository)
            : base(repository)
        {

        }
    }
}