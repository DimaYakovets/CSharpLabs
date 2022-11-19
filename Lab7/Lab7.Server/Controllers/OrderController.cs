using Lab7.Models;
using Lab7.Client.Services;

namespace Lab7.Controllers
{
    public sealed class OrderController : GenericController<Order>
    {
        public OrderController(IRepository<Order> repository)
            : base(repository)
        {

        }
    }
}