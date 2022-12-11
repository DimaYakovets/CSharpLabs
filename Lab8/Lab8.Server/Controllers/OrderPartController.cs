using Lab8.Models;
using Lab8.Services;

namespace Lab8.Controllers
{
    public sealed class OrderPartController : GenericController<OrderPart>
    {
        public OrderPartController(IRepository<OrderPart> repository)
            : base(repository)
        {

        }
    }
}