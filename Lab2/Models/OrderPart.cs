using System;
using System.Collections.Generic;

namespace Lab2
{
    public partial class OrderPart
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int PizzaId { get; set; }
        public double Discount { get; set; }
        public int Count { get; set; }

        public Order Order { get; set; } = null!;
        public Pizza Pizza { get; set; } = null!;
    }
}
