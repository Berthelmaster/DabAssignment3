using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SocialNetworkApplication.Model;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SocialNetworkApplication.DummyData
{
    public class DummyData
    {
        private readonly IMongoCollection<User> _user;
        private readonly IMongoCollection<Post> _post;
        private readonly IMongoCollection<Post> _comment;
        private readonly IMongoCollection<Circle> _circle;

        public DummyData(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("SocialMediaDb"));
            var database = client.GetDatabase("SocialMediaDb");
            _user = database.GetCollection<User>("User");
            _post = database.GetCollection<Post>("Post");
            _comment = database.GetCollection<Post>("Comment");
            _circle = database.GetCollection<Circle>("Circle");

            UserDummy(_user);
            PostDummy(_post);
            CommentDummy(_comment);
            CircleDummy(_circle);
        }


        static async void UserDummy(IMongoCollection<User> user)
        {
            var users = new List<User>
            {
                new User
                {
                    Id              = "00001",
                    Name            = "Hans",
                    Gender          = "Male",
                    Age             = "26",
                    BlockedList     = new List<string> {"00001"},
                    Followers       = new List<string> {"00001"},
                    Following       = new List<string> {"00001"},
                    Circles         = new List<string> {"00001"},
                    Posts           = new List<string> {"00001"}
                },
                new User
                {
                    Id              = "00002",
                    Name            = "Anne",
                    Gender          = "Female",
                    Age             = "25",
                    BlockedList     = new List<string> {"00002"},
                    Followers       = new List<string> {"00002"},
                    Following       = new List<string> {"00002"},
                    Circles         = new List<string> {"00002"},
                    Posts           = new List<string> {"00002"}
                },
                new User
                {
                    Id              = "00003",
                    Name            = "Mads",
                    Gender          = "male",
                    Age             = "27",
                    BlockedList     = new List<string> {"00003"},
                    Followers       = new List<string> {"00003"},
                    Following       = new List<string> {"00003"},
                    Circles         = new List<string> {"00003"},
                    Posts           = new List<string> {"00003"}
                }
            };
            await user.InsertManyAsync(users);
        }
        static async void PostDummy(IMongoCollection<Post> post)
        {
            var posts = new List<Post>
            {
                new Post
                {
                    Id              = "00001",
                    Circle          = "00001",
                    TextContent     = "Post 1",
                    ImageContent    = null,
                    Privacy         = "Public",
                    Autoher         = "00001",
                    CreationTime    = "10/05/2018",
                    Comments        = new List<string> {"00001"}
                },
                new Post
                {
                    Id              = "00002",
                    Circle          = "00002",
                    TextContent     = "Post 2",
                    ImageContent    = null,
                    Privacy         = "Public",
                    Autoher         = "00002",
                    CreationTime    = "11/05/2018",
                    Comments        = new List<string> {"00002"}
                },
                new Post
                {
                    Id              = "00003",
                    Circle          = "00003",
                    TextContent     = "Post 3",
                    ImageContent    = null,
                    Privacy         = "Public",
                    Autoher         = "00003",
                    CreationTime    = "12/05/2018",
                    Comments        = new List<string> {"00003"}
                }
            };
            await user.InsertManyAsync(users);
        }
        static async void CircleDummy(IMongoCollection<Circle> circle)
        {
            var circle = new List<Post>
            {
                new Circle
                {
                    Id              = "00001",
                    Name            = "Main Circle",
                    Posts           = new List<string> {"00001"},
                    User            = new List<string> {"00001"}
                },
                new Circle
                {
                    Id              = "00002",
                    Name            = "Work",
                    Posts           = new List<string> {"00002"},
                    User            = new List<string> {"00002"}
                },
                new Circle
                {
                    Id              = "00003",
                    Name            = "School",
                    Posts           = new List<string> {"00003"},
                    User            = new List<string> {"00003"}
                }
            };
            await user.InsertManyAsync(users);
        }
        static async void CommentDummy(IMongoCollection<Comment> comment)
        {
            var comment = new List<Post>
            {
                new Comment
                {
                    Id              = "00001",
                    Name            = "00001",
                    Text            = "Nice",
                    CreationTime    = "10/05/2018"
                },
                new Comment
                {
                    Id              = "00002",
                    Name            = "00002",
                    Text            = "Cool",
                    CreationTime    = "11/05/2018"
                },
                new Comment
                {
                    Id              = "00003",
                    Name            = "00003",
                    Text            = "Amazing",
                    CreationTime    = "12/05/2018"
                }
            };
            await user.InsertManyAsync(users);
        }
    }
}