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
    public class CommentController : ControllerBase
    {
        private readonly CommentService _commentService;
        private readonly PostService _postService;

        public IConfiguration Configuration { get; }

        public CommentController(CommentService commentService, PostService postService)
        {
            _commentService = commentService;
            _postService = postService;
        }

        

        [HttpGet]
        public ActionResult<List<Comment>> Get()
        {
            return _commentService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetComment")]
        public ActionResult<Comment> Get(string Id)
        {
            var circle = _commentService.Get(Id);

            if (circle == null)
            {
                return NotFound();
            }

            return circle;
        }

        [HttpPost("{PostId}")]
        public ActionResult CreateComment(string PostId, Comment comment)
        {
            var post = _postService.Get(PostId);


            if (post == null)
            {
                return NoContent();
            }

            _commentService.Create(comment);


            return Ok();
        }

        [HttpPut("{Id:length(24)}")]
        public IActionResult Update(string Id, Comment circleIn)
        {
            var circle = _commentService.Get(Id);

            if (circle == null)
            {
                return NotFound();
            }

            _commentService.Update(Id, circleIn);
            return NoContent();
        }

        [HttpDelete("{Id:length(24)}")]
        public IActionResult Delete(string Id)
        {
            var circle = _commentService.Get(Id);

            if (circle == null)
            {
                return NotFound();
            }

            _commentService.Remove(circle.Id);

            return NoContent();
        }
    }
}
