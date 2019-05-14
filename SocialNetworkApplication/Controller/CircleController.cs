using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialNetworkApplication.Model;
using SocialNetworkApplication.Services;

namespace SocialNetworkApplication.Controller
{
    [Route("API/[controller]")]
    [ApiController]
    public class CircleController
    {
        private readonly CircleService _circleService;

        public CircleController(CircleService circleService)
        {
            _circleService = circleService;
        }

        [HttpGet]
        public ActionResult<List<Circle>> Get()
        {
            return _circleService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "getName")]
        public ActionResult<Circle> Get(string Id)
        {
            var circle = _circleService.Get(Id);
            if(circle==null)
            {
                return NotFound();
            }
            return circle;
        }

        [HttpPost]
        public ActionResult<Circle> Create(Circle circle)
        {

        }


    }
}
