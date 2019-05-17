﻿using System;
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

            _userController.Get(UserID);

            var allPosts = _postController.Get();

            foreach (var post in allPosts)
            {
                
            }

            var UserObj = new UserService();

            Console.WriteLine($"{UserObj.Get(UserID)}");

            if (UserObj.Get(UserID) == null)
            {
                Console.WriteLine($"User with ID {UserID} not found try again");
            }
            else
            {
                Console.WriteLine("All current feeds");
            }           
            
        }

        public void ShowWall(string UserID, string GuestId)
        {
            if(_postController.Get(UserID)==null)
            {
                Console.WriteLine("User not found incorrect user ID ");
            }
            else
            {
                _postController.


            }
   
        }

        public void CreatePost(string OwnerID, string Content, string Circle, string privacy_)
        {
            var post = new Post
            {
                Id = OwnerID,

                ImageContent = Content,

                Privacy = privacy_,
            };
            post.TextContent = Content;
            _postController.Create(post);
            
            
        }

        public void CreateComment(string PostID, string Comment)
        {
            var commentObj = new Comment
            {
                Id = PostID,
                Text = Comment,
            };

            _commentController.Create(commentObj);

        }

    }
}
