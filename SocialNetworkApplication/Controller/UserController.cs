using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialNetworkApplication.Model;
using SocialNetworkApplication.Services;

namespace SocialNetworkApplication.Controller
{
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly CircleService _circleService;
        

        public UserController(UserService userService, CircleService circleService)
        {
            _userService = userService;
            _circleService = circleService;
        }

        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return _userService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetUser")]
        public ActionResult<User> Get(string Id)
        {
            var circle = _userService.Get(Id);

            if (circle == null)
            {
                return NotFound();
            }

            return circle;
        }

        [HttpPost]
        public ActionResult<User> Create(User circle)
        {
            _userService.Create(circle);

            return CreatedAtRoute("GetUser", new { Id = circle.Id.ToString() }, circle);
        }

        [HttpPut("{Id:length(24)}")]
        public IActionResult Update(string Id, User circleIn)
        {
            var circle = _userService.Get(Id);

            if (circle == null)
            {
                return NotFound();
            }

            _userService.Update(Id, circleIn);
            return NoContent();
        }

        [HttpDelete("{Id:length(24)}")]
        public IActionResult Delete(string Id)
        {
            var circle = _userService.Get(Id);

            if (circle == null)
            {
                return NotFound();
            }

            _userService.Remove(circle.Id);

            return NoContent();
        }
    }
}
