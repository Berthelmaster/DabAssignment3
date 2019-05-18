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
    public class FeedController : ControllerBase
    {
        private readonly FeedService _feedService;
        private readonly UserService _userService;
        private readonly CircleService _circleService;
        public IConfiguration Configuration { get; }

        public FeedController(FeedService feedService, UserService userService, CircleService circleService)
        {
            _feedService = feedService;
            _userService = userService;
            _circleService = circleService;
        }

        public FeedController()
        {
            _feedService = new FeedService();
            _userService = new UserService(Configuration);
            _circleService = new CircleService(Configuration);
        }

        [HttpGet]
        public ActionResult<List<Feed>> Get()
        {
            return _feedService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetFeed")]
        public ActionResult<Feed> Get(string Id)
        {
            var circle = _feedService.Get(Id);

            if (circle == null)
            {
                return NotFound();
            }

            return circle;
        }

        [HttpPost]
        public ActionResult<Feed> Create(Feed circle)
        {
            _feedService.Create(circle);

            return CreatedAtRoute("GetFeed", new { Id = circle.Id.ToString() }, circle);
        }

        [HttpPut("{Id:length(24)}")]
        public IActionResult Update(string Id, Feed circleIn)
        {
            var circle = _feedService.Get(Id);

            if (circle == null)
            {
                return NotFound();
            }

            _feedService.Update(Id, circleIn);
            return NoContent();
        }

        [HttpDelete("{Id:length(24)}")]
        public IActionResult Delete(string Id)
        {
            var circle = _feedService.Get(Id);

            if (circle == null)
            {
                return NotFound();
            }

            _feedService.Remove(circle.Id);

            return NoContent();
        }
    }
}
