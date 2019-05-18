using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialNetworkApplication.Model;
using SocialNetworkApplication.Services;

namespace SocialNetworkApplication.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        private readonly CircleService _circleService;
        private readonly UserService _userService;
        private readonly PostService _postService;
        private readonly string dateTimeFormat = "MM/dd/yyyy";


        public CommandController(CircleService circleService, UserService userService, PostService postService)
        {
            _circleService = circleService;
            _userService = userService;
            _postService = postService;
        }

        [HttpGet("{userid}")]
        public ActionResult<List<Post>> ShowFeed(string UserID)
        {
            var allCircles = _circleService.Get().ToList();

            List<Circle> userCircles = new List<Circle>();

            foreach (var circle in allCircles)
            {
                foreach (var circleUser in circle.Users)
                {
                    if (circleUser.Equals(UserID))
                    {
                        userCircles.Add(circle);
                    }
                }
            }

            // var userCircles = _circleService.Get().FindAll(c => c.Users.Contains(UserID)).ToList();
            
            List<string> allUserPostsStr = new List<string>();

            foreach (var userCircle in userCircles)
            {
                foreach (var userCirclePost in userCircle.Posts)
                {
                    allUserPostsStr.Add(userCirclePost);
                }
            }

            List<Post> allUserPosts = new List<Post>();

            foreach (var allUserPost in allUserPostsStr)
            {
                allUserPosts.Add(_postService.Get(allUserPost));
            }
            // Plausible , not sure about this one
            //var allUserPosts = _postService.Get().FindAll(p => p.Circle. userCircles.Contains(p.Circle)).ToList();

            return allUserPosts;
        }

        //[HttpGet("{UserID}/{guestId}")]
        //public ActionResult<List<Post>> ShowWall(string UserID, string GuestId)
        //{

        //    if (UserID.Equals(GuestId))
        //    {
        //        var userPosts = _postService.Get().FindAll(p => p.Author.Equals(UserID));

        //        return userPosts;
        //    }


        //    var userCircles = _circleService.Get().FindAll(c => c.Users.Contains(UserID));

        //    List<Circle> userAndGuestCircles = new List<Circle>();

        //    foreach (var circle in userCircles)
        //    {
        //        foreach (var user in circle.Users)
        //        {
        //            if (user.Equals(GuestId))
        //            {
        //                userAndGuestCircles.Add(circle);
        //            }
        //        }
        //    }

        //    List<Post> userAndGuestsPosts = new List<Post>();

        //    foreach (var userAndGuestCircle in userAndGuestCircles)
        //    {
        //        if (userAndGuestCircle.Posts.Count == 0)
        //        {
        //            return NoContent();
        //        }
        //        foreach (var post in userAndGuestCircle.Posts)
        //        {
        //            if (post.Author.Equals(UserID))
        //            {
        //                userAndGuestsPosts.Add(post);
        //            }
        //        }
        //    }

        //    return userAndGuestsPosts;
        //}

        /*
        public void CreatePost(string OwnerID, string Content, string Circle, string privacy_)
        {
            var circle = _circleController.Get(Circle).Value;

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
        */
    }
}
