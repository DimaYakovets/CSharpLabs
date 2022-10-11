using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace Lab3.Models
{
    public sealed class OrderPart
    {
        public Pizza Pizza { get; set; }
        public int Count { get; set; }
        public double Discount { get; set; }
    }

    public sealed class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public Client Client { get; set; }
        public OrderPart[] OrderParts { get; set; }
    }
}
