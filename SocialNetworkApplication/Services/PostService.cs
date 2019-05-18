using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SocialNetworkApplication.Model;

namespace SocialNetworkApplication.Services
{
    public class PostService
    {
        private readonly IMongoCollection<Post> _posts;
        public PostService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("DabAssignment3"));
            var database = client.GetDatabase("DabAssignment3");
            _posts = database.GetCollection<Post>("Circle");

            /*
            var connectionstring = "SocialNetworkPlatform";
            var client = new MongoClient(connectionstring);
            var database = client.GetDatabase(connectionstring);
            _circles = database.GetCollection<Circle>("Circles");
            */

        }

        public List<Post> Get()
        {
            return _posts.Find(Post => true).ToList();
        }

        public Post Get(string id)
        {
            return _posts.Find<Post>(Post => Post.Id.Equals(id)).FirstOrDefault();
        }

        public Post Create(Post post)
        {
            _posts.InsertOne(post);
            return post;
        }

        public void Remove(Post post)
        {
            _posts.DeleteOne(p => p.Id == post.Id);
        }

        public void Remove(string id)
        {
            _posts.DeleteOne(post => post.Id.Equals(id));
        }

        public void Update(string id, Post post)
        {
            _posts.ReplaceOne(p => p.Id.Equals(id), post);
        }


    }
}
