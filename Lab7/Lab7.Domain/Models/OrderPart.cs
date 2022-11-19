using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab7.Models
{
    public sealed class OrderPart : IModel
    {
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int PizzaId { get; set; }
        [Required]
        public double Discount { get; set; }
        [Required]
        public int Count { get; set; }

        public  Order Order { get; set; } = null!;
        public  Pizza Pizza { get; set; } = null!;
    }
}
