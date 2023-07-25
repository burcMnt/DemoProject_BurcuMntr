using ApplicationCore.Entities.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.MongoEntity
{
    public class Buildings
    {
        [JsonIgnore]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public Guid UserId { get; set; }
        public BuildingTypeEnum BuildingType { get; set; }
        public decimal BuildingCost { get; set; }
        public long ConstructionTime { get; set; }


    }
}
