using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab7.Models
{
    public sealed class Order : IModel
    {
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required] 
        public int ClientId { get; set; }

        public  Client Client { get; set; }
        public  ICollection<OrderPart> OrderParts { get; set; }
    }
}
