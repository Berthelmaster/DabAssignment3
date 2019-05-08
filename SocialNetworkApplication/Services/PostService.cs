using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using SocialNetworkApplication.Model;

namespace SocialNetworkApplication.Services
{
    public class PostService
    {
        private readonly IMongoCollection<Post> _posts;
        public PostService()
        {
            var connectionstring = "SocialNetworkPlatform";
            var client = new MongoClient(connectionstring);
            var database = client.GetDatabase(connectionstring);
            _posts = database.GetCollection<Post>("Posts");

        }

        public List<Post> Get()
        {
            return _posts.Find(Post => true).ToList();
        }
    }
}
