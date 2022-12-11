using Lab8.Models;
using Lab8.Services;

namespace Lab8.Controllers
{
    public sealed class ClientController : GenericController<Models.Client>
    {
        public ClientController(IRepository<Models.Client> repository)
            : base(repository)
        {

        }
    }
}
