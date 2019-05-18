using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SocialNetworkApplication.Model;
using SocialNetworkApplication.Services;


namespace SocialNetworkApplication.Controller
{
    [Route("API/[controller]")]
    [ApiController]
    public class CircleController : ControllerBase
    {
        private readonly CircleService _circleService;
        private readonly UserService _userService;
        private readonly PostService _postService;
        

        public CircleController(CircleService circleService, UserService userService, PostService postService)
        {
            _circleService = circleService;
            _userService = userService;
            _postService = postService;
        }

        public CircleController()
        {
            _postService = new PostService();
            _userService = new UserService();
            _circleService = new CircleService();
        }

        [HttpGet]
        public ActionResult<List<Circle>> Get()
        {
            return _circleService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetCircle")]
        public ActionResult<Circle> Get(string Id)
        {
            var circle = _circleService.Get(Id);

            if(circle == null)
            {
                return NotFound();
            }

            return circle;
        }

        [HttpPost]
        public ActionResult<Circle> Create(Circle circle)
        {
            _circleService.Create(circle);
            
            return CreatedAtRoute("GetCircle", new {Id=circle.Id.ToString()}, circle);
        }

        [HttpPut("{Id:length(24)}")]
        public IActionResult CreatePost(Circle circle, Post post)
        {
            post.Circle = circle;

            circle.Posts.Add(post);

            _circleService.Create(circle);

            _postService.Create(post);

            return NoContent();
        }

        [HttpPut("{Id:length(24)}")]
        public IActionResult AddUser(Circle circle, string userId)
        {
            var u = _userService.Get(userId);

            if (u == null)
            {
                return NotFound();
            }

            var c = _circleService.Get(circle.Id);

            if (c == null)
            {
                return NotFound();
            }

            circle.Users.Add(userId);

            _circleService.Update(circle.Id, circle);

            return NoContent();
        }

        [HttpPut("{Id:length(24)}")]
        public IActionResult Update(string Id, Circle circleIn)
        {
            var circle = _circleService.Get(Id);

            if(circle==null)
            {
                return NotFound();
            }

            _circleService.Update(Id, circleIn);
            return NoContent();
        }

        [HttpDelete("{Id:length(24)}")]
        public IActionResult Delete(string Id)
        {
            var circle = _circleService.Get(Id);

            if (circle == null)
            {
                return NotFound();
            }

            _circleService.Remove(circle.Id);

            return NoContent();
        }
    }
}
