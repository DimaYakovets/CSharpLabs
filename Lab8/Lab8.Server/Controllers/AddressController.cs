using Lab8.Models;
using Lab8.Services;

namespace Lab8.Controllers
{
    public sealed class AddressController : GenericController<Address>
    {
        public AddressController(IRepository<Address> repository)
            : base(repository)
        {

        }
    }
}