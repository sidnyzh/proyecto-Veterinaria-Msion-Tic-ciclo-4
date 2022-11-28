using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Pet
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        [JsonIgnore]
        public ObjectId Id { get; set; }

        [BsonElement("owner")]
        public string Owner { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("species")]
        public string Species { get; set; }

        [BsonElement("birthdate")]
        public DateOnly Birthdate { get; set; }

        [BsonElement("race")]
        public string Race { get; set; }

        [BsonElement("color")]
        public string Color { get; set; }

        [BsonElement("sexo")]
        public char Sexo { get; set; }


    }
}
