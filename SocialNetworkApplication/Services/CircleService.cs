using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using SocialNetworkApplication.Model;

namespace SocialNetworkApplication.Services
{
    public class CircleService
    {
        private readonly IMongoCollection<Circle> _circles;
        public CircleService()
        {
            var connectionstring = "SocialNetworkPlatform";
            var client = new MongoClient(connectionstring);
            var database = client.GetDatabase(connectionstring);
            _circles = database.GetCollection<Circle>("Circles");

        }

        public Circle Get(string id)
        {
            return _circles.Find<Circle>(c => c.Id.Equals(id)).FirstOrDefault();
        }

        public List<Circle> Get()
        {
            return _circles.Find(Circle => true).ToList();
        }

        public Circle Create(Circle circle)
        {
            _circles.InsertOne(circle);
            return circle;
        }

        public void Remove(Circle circle)
        {
            _circles.DeleteOne(c => c.Id == circle.Id);
        }

        public void Remove(string id)
        {
            _circles.DeleteOne(circle => circle.Id.Equals(id));
        }

        public void Update(string id, Circle circle)
        {
            _circles.ReplaceOne(c => c.Id.Equals(id), circle);
        }

        public void AddUser(Circle circle, string userId)
        {
            circle.Users.Add(userId);
            Update(circle.Id, circle);
        }

        public void AddPost(Circle circle, Post post)
        {
            circle.Posts.Add(post);
            Update(circle.Id, circle);
        }
    }
}
