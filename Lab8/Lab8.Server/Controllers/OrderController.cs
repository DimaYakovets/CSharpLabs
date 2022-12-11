using Lab8.Models;
using Lab8.Services;

namespace Lab8.Controllers
{
    public sealed class OrderController : GenericController<Order>
    {
        public OrderController(IRepository<Order> repository)
            : base(repository)
        {

        }
    }
}