using System;
using System.Collections.Generic;

namespace Lab2
{
    public partial class Address
    {
        public int Id { get; set; }
        public string City { get; set; } 
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public int FlatNumber { get; set; }

        public ICollection<Client> Clients { get; set; }
    }
}
