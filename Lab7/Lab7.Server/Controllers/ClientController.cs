using Lab7.Models;
using Lab7.Client.Services;

namespace Lab7.Controllers
{
    public sealed class ClientController : GenericController<Models.Client>
    {
        public ClientController(IRepository<Models.Client> repository)
            : base(repository)
        {

        }
    }
}
