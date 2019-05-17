using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using SocialNetworkApplication.Services;
using SocialNetworkApplication.Controller;
using SocialNetworkApplication.Model;
using System.Collections.ObjectModel;

namespace SocialNetworkApplication
{
    public class Command
    {
        private readonly UserController _userController;
        private readonly PostController _postController;
        private readonly CircleController _circleController;
        private readonly CommentController _commentController;
        private readonly string dateTimeFormat = "MM/dd/yyyy";


        public Command()
        {
            _userController = new UserController();
            _postController = new PostController();
            _circleController = new CircleController();
            _commentController = new CommentController();
        }

        public void ShowFeed(string UserID)
        {
            Console.WriteLine($"Finding user with id {UserID}");
            var userCircles =_circleController.Get().Value.FindAll(c => c.Users.Contains(UserID)).ToList();

            // Plausible , not sure about this one
            var allUserPosts = _postController.Get().Value.FindAll(p => p.Author.Equals(UserID) || userCircles.Contains(p.Circle));

            foreach(var post in allUserPosts)
            {
                Console.WriteLine(post.Author);
                Console.WriteLine(post.CreationTime.ToString(dateTimeFormat));
                Console.WriteLine(post.TextContent);
                Console.WriteLine();
            }
            
        }

        public void ShowWall(string UserID, string GuestId)
        {
            List<Post> userPosts;

            if (UserID.Equals(GuestId))
            {
                userPosts = _postController.Get().Value.FindAll(p => p.Author.Equals(UserID));
            }

            else
            {
                userPosts= _postController.Get().Value.FindAll(p => p.Author.Equals(UserID) && p.Privacy.ToLower().Equals("public"));
            }

            foreach (var userPost in userPosts)
            {
                Console.WriteLine(userPost.Author);
                Console.WriteLine(userPost.CreationTime.ToString(dateTimeFormat));
                Console.WriteLine(userPost.TextContent);
                Console.WriteLine();
            }

        }

        public void CreatePost(string OwnerID, string Content, string Circle, string privacy_)
        {
            var circle =_circleController.Get(Circle).Value;

            var post = new Post()
            {
                Author = OwnerID,

                ImageContent = Content,

                Circle = circle,

                Privacy = privacy_,
            };

            post.TextContent = Content;

            circle.Posts.Add(post);

            _circleController.Update(circle.Id, circle);
            
            _postController.Create(post);
        }

        public void CreateComment(string PostID, string Comment)
        {
            var post = _postController.Get(PostID).Value;

            if (post == null)
            {
                return;
            }

            var commentObj = new Comment
            {
                Text = Comment,
            };

            post.Comments.Add(commentObj);

            _postController.Update(post.Id, post);

            _commentController.Create(commentObj);
        }

    }
}
