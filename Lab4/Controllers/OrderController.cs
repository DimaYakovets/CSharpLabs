using Lab4.Models;
using Lab4.Services;

namespace Lab4.Controllers
{
    public sealed class OrderController : GenericController<Order>
    {
        public OrderController(IRepository<Order> repository)
            : base(repository)
        {

        }
    }
}