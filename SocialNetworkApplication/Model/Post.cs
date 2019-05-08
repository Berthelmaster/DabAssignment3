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
        // Core Attributes
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("ImageContent")]
        public string ImageContent { get; set; }
        [BsonElement("TextContent")]
        public string TextContent { get; set; }
        [BsonElement("CreationTime")]
        public DateTime CreationTime { get; set; }
        

       

       

    }
}
