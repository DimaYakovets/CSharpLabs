using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace Lab3.Models
{
    public partial class Client
    {
        public string Firstname { get; set; } 
        public string Surname { get; set; } 
        public string Patronymic { get; set; } 
        public string Phone { get; set; } 
        public Address Address { get; set; }
    }
}
