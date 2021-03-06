﻿using System;
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
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly CircleService _circleService;
        //private readonly PostService _postService;
        public IConfiguration Configuration { get; }



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
        public ActionResult<User> Create(User user)
        {
            _userService.Create(user);

            return CreatedAtRoute("GetUser", new { Id = user.Id.ToString() }, user);
        }

        [HttpPost]
        public ActionResult<Circle> CreateCircle(Circle circle, string userId)
        {
            var u = _userService.Get(userId);

            // Maybe name
            u.Circles.Add(circle.Id);

            circle.Users.Add(userId);

            _circleService.Create(circle);

            _userService.Update(userId, u);

            return CreatedAtRoute("GetCircle", new { Id = circle.Id.ToString() }, circle);
        }


        //[HttpPut("{Id:length(24)}")]
        //public IActionResult CreatePublicPost(string userId, Post post)
        //{
        //    var u = _userService.Get(userId);

        //    if (u == null)
        //    {
        //        return NotFound();
        //    }

        //    post.Author = userId;

        //    u.Posts.Add(post);

        //    _userService.Update(userId, u);

        //    return NoContent();
        //}

        

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
