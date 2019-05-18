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
                    Id              = "000000000000000000000001",
                    Name            = "Hans",
                    Gender          = "Male",
                    Age             = 26,
                    BlockedList     = new List<string>(),
                    Followings      = new List<string>
                    {
                        "000000000000000000000002",
                        "000000000000000000000003",
                        "000000000000000000000004",
                        "000000000000000000000005",
                        "000000000000000000000006",
                        "000000000000000000000007"
                    },
                    Follows         = new List<string>
                    {
                        "000000000000000000000002",
                        "000000000000000000000003",
                        "000000000000000000000004",
                        "000000000000000000000005",
                        "000000000000000000000006",
                        "000000000000000000000007"
                    },
                    Circles         = new List<string>
                    {
                        "000000000000000000000011",
                        "000000000000000000000013",
                    },
                   
                },
                new User
                {
                    Id              = "000000000000000000000002",
                    Name            = "Anne",
                    Gender          = "Female",
                    Age             = 25,
                    BlockedList     = new List<string>
                    {
                        "000000000000000000000006",
                        "000000000000000000000007"
                    },
                    Followings      = new List<string>
                    {
                        "000000000000000000000001",
                        "000000000000000000000003"
                    },
                    Follows         = new List<string>
                    {
                        "000000000000000000000001",
                        "000000000000000000000003",
                        "000000000000000000000004",
                        "000000000000000000000005"
                    },
                    Circles         = new List<string> { "000000000000000000000011" }
                },
                new User
                {
                    Id              = "000000000000000000000003",
                    Name            = "Mads",
                    Gender          = "male",
                    Age             = 27,
                    BlockedList     = new List<string>
                    {
                        "000000000000000000000006",
                        "000000000000000000000007"
                    },
                    Followings      = new List<string>
                    {
                        "000000000000000000000001",
                        "000000000000000000000002"
                    },
                    Follows         = new List<string>
                    {
                        "000000000000000000000001",
                        "000000000000000000000002",
                        "000000000000000000000004"
                    },
                    Circles         = new List<string> {"000000000000000000000011"},
                },
                new User
                {
                    Id              = "000000000000000000000004",
                    Name            = "Grete",
                    Gender          = "Female",
                    Age             = 26,
                    BlockedList     = new List<string>
                    {
                        "000000000000000000000006",
                    },
                    Followings      = new List<string> {"000000000000000000000001"},
                    Follows         = new List<string> {"000000000000000000000001"},
                    Circles         = new List<string>
                    {
                        "000000000000000000000011",
                        "000000000000000000000013"
                    },

                },
                new User
                {
                    Id              = "000000000000000000000005",
                    Name            = "Jessie",
                    Gender          = "Female",
                    Age             = 25,
                    BlockedList     = new List<string> {"000000000000000000000007"},
                    Followings      = new List<string>
                    {
                        "000000000000000000000001",
                        "000000000000000000000006"
                    },
                    Follows         = new List<string> {"000000000000000000000001"},
                    Circles         = new List<string>
                    {
                        "000000000000000000000011",
                        "000000000000000000000013"
                    }
                },
                new User
                {
                    Id              = "000000000000000000000006",
                    Name            = "Thomas",
                    Gender          = "male",
                    Age             = 27,
                    BlockedList     = new List<string>(),
                    Followings      = new List<string>
                    {
                        "000000000000000000000001",
                        "000000000000000000000007"
                    },
                    Follows         = new List<string>
                    {
                        "000000000000000000000001",
                        "000000000000000000000007",
                        "000000000000000000000005"
                    },
                    Circles         = new List<string>
                    {
                        "000000000000000000000011",
                        "000000000000000000000012",
                    },
                },
                new User
                {
                    Id              = "000000000000000000000007",
                    Name            = "Abdul",
                    Gender          = "male",
                    Age             = 27,
                    BlockedList     = new List<string> {"000000000000000000000002"},
                    Followings      = new List<string>
                    {
                        "000000000000000000000001",
                        "000000000000000000000006"
                    },
                    Follows         = new List<string>
                    {
                        "000000000000000000000001",
                        "000000000000000000000006"
                    },
                    Circles         = new List<string>
                    {
                        "000000000000000000000011",
                        "000000000000000000000012"
                    },
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
                    Id              = "000000000000000000000008",
                    Circle          =  new Circle()
                    {
                        Id = "000000000000000000000011"
                    },
                    TextContent     = "Post 1",
                    ImageContent    = null,
                    Privacy         = "Public",
                    Author          = "000000000000000000000001",
                    CreationTime    = DateTime.Today,
                    Comments        = new List<Comment>()
                    {
                        new Comment(){Id = "000000000000000000000014"}
                    }
                },
                new Post
                {
                    Id              = "000000000000000000000009",
                    Circle          = new Circle(){Id = "000000000000000000000013"},
                    TextContent     = "Post 2",
                    ImageContent    = null,
                    Privacy         = "Group",
                    Author          = "000000000000000000000005",
                    CreationTime    = new DateTime(2000, 12, 12),
                    Comments        = new List<Comment>()
                    {
                        new Comment(){Id = "000000000000000000000015"}
                    }
                },
                new Post
                {
                    Id              = "000000000000000000000010",
                    Circle          = new Circle(){Id = "000000000000000000000012"},
                    TextContent     = "Post 3",
                    ImageContent    = null,
                    Privacy         = "Group",
                    Author          = "000000000000000000000006",
                    CreationTime    = new DateTime(1980, 11, 12),
                    Comments        = new List<Comment>()
                    {
                        new Comment(){Id = "000000000000000000000016"}
                    }
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
                    Id              = "000000000000000000000011",
                    Name            = "Hans main Circle",
                    Posts           = new List<Post>()
                    {
                        new Post(){Id = "000000000000000000000008"}
                    },
                    Users           = new List<string>
                    {
                        "000000000000000000000001",
                        "000000000000000000000002",
                        "000000000000000000000003",
                        "000000000000000000000004",
                        "000000000000000000000005",
                        "000000000000000000000006",
                        "000000000000000000000007"
                    }
                },
                new Circle
                {
                    Id              = "000000000000000000000012",
                    Name            = "Work",
                    Posts           = new List<Post>()
                    {
                        new Post(){Id = "000000000000000000000010"}
                    },
                    Users            = new List<string>
                    {
                        "000000000000000000000006",
                        "000000000000000000000007"
                    }
                },
                new Circle
                {
                    Id              = "000000000000000000000013",
                    Name            = "School",
                    Posts           = new List<Post>()
                    {
                        new Post(){Id = "000000000000000000000009"}
                    },
                    Users            = new List<string>
                    {
                        "000000000000000000000001",
                        "000000000000000000000004",
                        "000000000000000000000005"
                    }
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
                    Id              = "000000000000000000000014",
                    Author          = "000000000000000000000006",
                    Text            = "Nice",
                    CreationTime    = new DateTime(2019, 1, 19)
                },
                new Comment
                {
                    Id              = "000000000000000000000015",
                    Author          = "000000000000000000000004",
                    Text            = "Cool",
                    CreationTime    = DateTime.MinValue,
                },
                new Comment
                {
                    Id              = "000000000000000000000016",
                    Author          = "000000000000000000000007",
                    Text            = "Amazing",
                    CreationTime    = new DateTime(1990, 12, 12),
                }
            };
            await comment.InsertManyAsync(comments);
        }
    }
}