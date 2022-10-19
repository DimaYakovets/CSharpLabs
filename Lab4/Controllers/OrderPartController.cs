using Lab4.Models;
using Lab4.Services;

namespace Lab4.Controllers
{
    public sealed class OrderPartController : GenericController<OrderPart>
    {
        public OrderPartController(IRepository<OrderPart> repository)
            : base(repository)
        {

        }
    }
}