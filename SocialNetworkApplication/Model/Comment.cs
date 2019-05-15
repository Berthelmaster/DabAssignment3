﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SocialNetworkApplication.Model
{
    public class Comment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Author")]
        public string Author { get; set; }

        [BsonElement("Text")]
        public string Text { get; set; }

        [BsonElement("CreationTime")]
        public DateTime CreationTime { get; set; }
    }
}
