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
        private readonly IMongoCollection<Comment> _comment;
        private readonly IMongoCollection<Circle> _circle;

        public DummyData(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("DabAssignment3"));
            var database = client.GetDatabase("DabAssignment3");
            _user = database.GetCollection<User>("User");
            _post = database.GetCollection<Post>("Post");
            _comment = database.GetCollection<Comment>("Comment");
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
                    Id              = "084266996668950330219015",
                    Name            = "Hans",
                    Gender          = "Male",
                    Age             = 26,
                    BlockedList     = new List<string> {"00001"},
                    Followings      = new List<string> {"00001"},
                    Follows         = new List<string> {"00001"},
                    Circles         = new List<string> {"00001"},
                   
                },
                new User
                {
                    Id              = "661991884379144158665822",
                    Name            = "Anne",
                    Gender          = "Female",
                    Age             = 25,
                    BlockedList     = new List<string> {"00002"},
                    Followings      = new List<string> {"00002"},
                    Follows         = new List<string> {"00002"},
                    Circles         = new List<string> {"00002"}
                },
                new User
                {
                    Id              = "627411219309047218021817",
                    Name            = "Mads",
                    Gender          = "male",
                    Age             = 27,
                    BlockedList     = new List<string> {"00003"},
                    Followings      = new List<string> {"00003"},
                    Follows         = new List<string> {"00003"},
                    Circles         = new List<string> {"00003"},
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
                    Id              = "084266996668950330219015",
                    Circle          =  new Circle(),
                    TextContent     = "Post 1",
                    ImageContent    = null,
                    Privacy         = "Public",
                    Author          = "00001",
                    CreationTime    = DateTime.Today,
                    Comments        = new List<Comment>()
                },
                new Post
                {
                    Id              = "661991884379144158665822",
                    Circle          = new Circle(),
                    TextContent     = "Post 2",
                    ImageContent    = null,
                    Privacy         = "Public",
                    Author          = "00002",
                    CreationTime    = DateTime.Now,
                    Comments        = new List<Comment>()
                },
                new Post
                {
                    Id              = "627411219309047218021817",
                    Circle          = new Circle(),
                    TextContent     = "Post 3",
                    ImageContent    = null,
                    Privacy         = "Public",
                    Author          = "00003",
                    CreationTime    = DateTime.MaxValue,
                    Comments        = new List<Comment>()
                }
            };
            await post.InsertManyAsync(posts);
        }
        static async void CircleDummy(IMongoCollection<Circle> circle)
        {
            var circles = new List<Circle>
            {
                new Circle
                {
                    Id              = "084266996668950330219015",
                    Name            = "Main Circle",
                    Posts           = new List<Post>(),
                    Users           = new List<string> {"00001"}
                },
                new Circle
                {
                    Id              = "661991884379144158665822",
                    Name            = "Work",
                    Posts           = new List<Post>(),
                    Users            = new List<string> {"00002"}
                },
                new Circle
                {
                    Id              = "627411219309047218021817",
                    Name            = "School",
                    Posts           = new List<Post>(),
                    Users            = new List<string> {"00003"}
                }
            };
            await circle.InsertManyAsync(circles);
        }
        static async void CommentDummy(IMongoCollection<Comment> comment)
        {
            var comments = new List<Comment>
            {
                new Comment
                {
                    Id              = "084266996668950330219015",
                    Author          = "00001",
                    Text            = "Nice",
                    CreationTime    = new DateTime(2019, 1, 19)
                },
                new Comment
                {
                    Id              = "661991884379144158665822",
                    Author          = "00002",
                    Text            = "Cool",
                    CreationTime    = DateTime.MinValue,
                },
                new Comment
                {
                    Id              = "627411219309047218021817",
                    Author          = "00003",
                    Text            = "Amazing",
                    CreationTime    = new DateTime(1990, 12, 12),
                }
            };
            await comment.InsertManyAsync(comments);
        }
    }
}