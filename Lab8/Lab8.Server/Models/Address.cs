using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab8.Models
{
    public sealed class Address : IModel
    {
        public int Id { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public int HouseNumber { get; set; }
        [Required]
        public int FlatNumber { get; set; }

        public ICollection<Client> Clients { get; set; }
    }
}
