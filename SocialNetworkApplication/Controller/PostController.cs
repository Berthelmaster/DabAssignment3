using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SocialNetworkApplication.Model;
using SocialNetworkApplication.Services;

namespace SocialNetworkApplication.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly PostService _postService;
        private readonly CommentService _commentService;
        public IConfiguration Configuration { get; }

        public PostController(PostService postService, CommentService commentService)
        {
            _postService = postService;
            _commentService = commentService;
        }

        


        [HttpGet]
        public ActionResult<List<Post>> Get()
        {
            return _postService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetPost")]
        public ActionResult<Post> Get(string Id)
        {
            var circle = _postService.Get(Id);

            if (circle == null)
            {
                return NotFound();
            }

            return circle;
        }

        [HttpPost]
        public ActionResult<Post> Create(Post post)
        {
            _postService.Create(post);

            return CreatedAtRoute("GetPost", new { Id = post.Id.ToString() }, post);
        }
        /*
        [HttpPut("{Id:length(24)}")]
        public IActionResult CreateComment(Post post, Comment comment)
        {
            post.Comments.Add(comment);

            _commentService.Create(comment);

            _postService.Create(post);

            return NoContent();
        }
        */

        [HttpPut("{Id:length(24)}")]
        public IActionResult Update(string Id, Post circleIn)
        {
            var circle = _postService.Get(Id);

            if (circle == null)
            {
                return NotFound();
            }

            _postService.Update(Id, circleIn);
            return NoContent();
        }

        [HttpDelete("{Id:length(24)}")]
        public IActionResult Delete(string Id)
        {
            var circle = _postService.Get(Id);

            if (circle == null)
            {
                return NotFound();
            }

            _postService.Remove(circle.Id);

            return NoContent();
        }
    }
}
