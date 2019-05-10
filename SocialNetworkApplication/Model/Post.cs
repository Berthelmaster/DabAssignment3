using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SocialNetworkApplication.Model
{
    public class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        // Core Attributes
        [BsonElement("ImageContent")]
        public string ImageContent { get; set; }

        [BsonElement("TextContent")]
        public string TextContent { get; set; }

        [BsonElement("CreationTime")]
        public DateTime CreationTime { get; set; }

        [BsonElement("Comments")]
        public List<string> Comments { get; set; }
    }
}
