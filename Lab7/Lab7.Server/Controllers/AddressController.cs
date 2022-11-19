using Lab7.Models;
using Lab7.Client.Services;

namespace Lab7.Controllers
{
    public sealed class AddressController : GenericController<Address>
    {
        public AddressController(IRepository<Address> repository)
            : base(repository)
        {

        }
    }
}