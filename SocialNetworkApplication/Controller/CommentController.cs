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
        public IConfiguration Configuration { get; }

        public CommentController(CommentService commentService)
        {
            _commentService = commentService;
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

        [HttpPost]
        public ActionResult<Comment> Create(Comment circle)
        {
            _commentService.Create(circle);

            return CreatedAtRoute("GetComment", new { Id = circle.Id.ToString() }, circle);
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
