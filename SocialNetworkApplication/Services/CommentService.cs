using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using SocialNetworkApplication.Model;

namespace SocialNetworkApplication.Services
{
    public class CommentService
    {
        private readonly IMongoCollection<Comment> _comments;
        public CommentService()
        {
            var connectionstring = "SocialNetworkPlatform";
            var client = new MongoClient(connectionstring);
            var database = client.GetDatabase(connectionstring);
            _comments = database.GetCollection<Comment>("Comments");

        }

        public List<Comment> Get()
        {
            return _comments.Find(Comment => true).ToList();
        }

        public Comment Get(string id)
        {
            return _comments.Find<Comment>(Comment => Comment.Id.Equals(id)).FirstOrDefault();
        }

        public Comment Create(Comment Comment)
        {
            _comments.InsertOne(Comment);
            return Comment;
        }

        public void Remove(Comment Comment)
        {
            _comments.DeleteOne(p => p.Id == Comment.Id);
        }

        public void Remove(string id)
        {
            _comments.DeleteOne(Comment => Comment.Id.Equals(id));
        }

        public void Update(string id, Comment Comment)
        {
            _comments.ReplaceOne(c => c.Id.Equals(id), Comment);
        }
    }
}
