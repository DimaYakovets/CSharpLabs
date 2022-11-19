using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab7.Models
{
    public sealed class Pizza : IModel
    {
        public int Id { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Description { get; set; }

        public ICollection<OrderPart> OrderParts { get; set; }
    }
}
