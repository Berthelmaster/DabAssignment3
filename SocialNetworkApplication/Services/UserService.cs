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

        public List<User> Get()
        {
            return _users.Find(User => true).ToList();
        }

        public User Create(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public void Remove(User user)
        {
            _users.DeleteOne(u => u.Id == user.Id);
        }

        public void Remove(string id)
        {
            _users.DeleteOne(user => user.Id.Equals(id));
        }

        public void Update(string id, User user)
        {
            _users.ReplaceOne(u => u.Id.Equals(id), user);
        }
    }
}
