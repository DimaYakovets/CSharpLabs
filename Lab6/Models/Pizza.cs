using System;
using System.Collections.Generic;

namespace Lab6.Models;

public partial class Pizza : IModel
{
    public int Id { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }

    public ICollection<OrderPart> OrderParts { get; set; }
}
