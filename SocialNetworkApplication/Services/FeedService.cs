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

        public Feed Get(string id)
        {
            return _feeds.Find<Feed>(a => a.Id.Equals(id)).FirstOrDefault();
        }

        public List<Feed> Get()
        {
            return _feeds.Find(Feed => true).ToList();
        }

        public Feed Create(Feed feed)
        {
            _feeds.InsertOne(feed);
            return feed;
        }

        public void Remove(Feed feed)
        {
            _feeds.DeleteOne(f => f.Id == feed.Id);
        }

        public void Remove(string id)
        {
            _feeds.DeleteOne(feed => feed.Id.Equals(id));
        }

        public void Update(string id, Feed feed)
        {
            _feeds.ReplaceOne(f => f.Id.Equals(id), feed);
        }

    }
}
