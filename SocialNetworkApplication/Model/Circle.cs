using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SocialNetworkApplication.Model
{
    public class Circle
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }



        [BsonElement("Posts")]
        public List<string> Posts { get; set; }

        [BsonElement("Users")]
        //Relations?
        public List<string> Users { get; set; }
    }
}
