using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace Lab3.Models
{
    public partial class Pizza
    {
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
