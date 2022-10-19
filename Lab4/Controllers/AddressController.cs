using Lab4.Models;
using Lab4.Services;

namespace Lab4.Controllers
{
    public sealed class AddressController : GenericController<Address>
    {
        public AddressController(IRepository<Address> repository)
            : base(repository)
        {

        }
    }
}