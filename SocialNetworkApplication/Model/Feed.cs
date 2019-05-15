using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SocialNetworkApplication.Model
{
    public class Feed
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Users")]
        public List<string> Users { get; set; }
        [BsonElement("Circles")]
        public List<string> Circles { get; set; }
        
    }
}
