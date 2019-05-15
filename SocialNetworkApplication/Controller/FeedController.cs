using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialNetworkApplication.Model;
using SocialNetworkApplication.Services;

namespace SocialNetworkApplication.Controller
{
    public class FeedController : ControllerBase
    {
        private readonly FeedService _feedService;

        public FeedController(FeedService feedService)
        {
            _feedService = feedService;
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
