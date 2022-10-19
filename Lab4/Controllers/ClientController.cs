using Lab4.Models;
using Lab4.Services;

namespace Lab4.Controllers
{
    public sealed class ClientController : GenericController<Client>
    {
        public ClientController(IRepository<Client> repository)
            : base(repository)
        {

        }
    }
}
