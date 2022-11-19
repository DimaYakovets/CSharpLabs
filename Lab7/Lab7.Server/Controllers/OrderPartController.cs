using Lab7.Models;
using Lab7.Client.Services;

namespace Lab7.Controllers
{
    public sealed class OrderPartController : GenericController<OrderPart>
    {
        public OrderPartController(IRepository<OrderPart> repository)
            : base(repository)
        {

        }
    }
}