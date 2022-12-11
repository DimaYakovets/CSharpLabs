using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab8.Models
{
    public sealed class Client : IModel
    {
        public int Id { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Patronymic { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public int AddressId { get; set; }

        public Address Address { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
