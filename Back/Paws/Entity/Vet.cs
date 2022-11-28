using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Domain.Entity
{
    public class Vet
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        [JsonIgnore]
        public ObjectId id { get; set; }

        [BsonElement("nit")]
        public string NIT { get; set; }

        [BsonElement("user")]
        public string user { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("address")]
        public string Address { get; set; }

        [BsonElement("phoneNumber")]
        public string PhoneNumber { get; set; }
    }
}
