using System;
using System.Collections.Generic;

namespace Lab2
{
    public partial class Pizza
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public ICollection<OrderPart> OrderParts { get; set; }
    }
}
