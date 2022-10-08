using System;
using System.Collections.Generic;

namespace Lab2
{
    public partial class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ClientId { get; set; }

        public Client Client { get; set; }
        public ICollection<OrderPart> OrderParts { get; set; }
    }
}
