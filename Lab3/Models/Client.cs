using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace Lab2
{
    public partial class Client
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Firstname { get; set; } 
        public string Surname { get; set; } 
        public string Patronymic { get; set; } 
        public string Phone { get; set; } 
        public int AddressId { get; set; }
    }
}
