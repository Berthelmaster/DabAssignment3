using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using SocialNetworkApplication.Model;

namespace SocialNetworkApplication.Services
{
    public class FeedService
    {
        private readonly IMongoCollection<Feed> _feeds;
        public FeedService()
        {
            var connectionstring = "SocialNetworkPlatform";
            var client = new MongoClient(connectionstring);
            var database = client.GetDatabase(connectionstring);
            _feeds = database.GetCollection<Feed>("Feeds");

        }

        public async Task<Feed> Get(string id)
        {
            return await _feeds.Find<Feed>(a => a.Id.Equals(id)).FirstOrDefaultAsync();
        }


    }
}
