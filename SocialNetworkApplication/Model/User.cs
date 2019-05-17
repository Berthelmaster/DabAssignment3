using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SocialNetworkApplication.Model
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Gender")]
        public string Gender { get; set; }

        [BsonElement("Age")]
        public int Age { get; set; }

        [BsonElement("BlockedList")]
        public List<string> BlockedList { get; set; }

        [BsonElement("Followers")]
        public List<string> Follows { get; set; }

        [BsonElement("Following")]
        public List<string> Followings { get; set; }
        
        [BsonElement("Circles")]
        public List<string> Circles{ get; set; }

        [BsonElement("Posts")]
        public List<Post> Posts{ get; set; }

        //[BsonElement("Feed")]
        //public ObjectId Feed { get; set; }
    }
}
