using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using SocialNetworkApplication.Model;

namespace SocialNetworkApplication.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _users;
        public UserService()
        {
            var connectionstring = "SocialNetworkPlatform";
            var client = new MongoClient(connectionstring);
            var database = client.GetDatabase(connectionstring);
            _users = database.GetCollection<User>("Users");
        }

        public User Get(string id)
        {
            return _users.Find<User>(fd => fd.Id == id).FirstOrDefault();
        }
    }
}
