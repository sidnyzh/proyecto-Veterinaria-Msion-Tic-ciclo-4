using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class MedicalRecord
    {
        [JsonIgnore]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId id { get; set; }

        [BsonElement("pet")]
        public string pet { get; set; }

        [BsonElement("weight")]
        public string weight { get; set; }

        [BsonElement("anapnesis")]
        public string Anapnesis { get; set; }

        [BsonElement("diagnosis")]
        public string Diagnosis { get; set; }

        [BsonElement("recomendations")]
        public string Recomendations { get; set; }   
  

    }
}
