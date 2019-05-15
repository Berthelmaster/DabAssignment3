using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialNetworkApplication.Model;
using SocialNetworkApplication.Services;

namespace SocialNetworkApplication.Controller
{
    public class PostController : ControllerBase
    {
        private readonly PostService _postService;

        public PostController(PostService postService)
        {
            _postService = postService;
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
        public ActionResult<Post> Create(Post circle)
        {
            _postService.Create(circle);

            return CreatedAtRoute("GetPost", new { Id = circle.Id.ToString() }, circle);
        }

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
