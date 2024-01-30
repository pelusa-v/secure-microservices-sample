using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Secure.SampleResourceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DogsController : ControllerBase
    {
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "DogsScope")]
        [HttpGet]
        public ActionResult<Dog> ListCats()
        {
            var dogs = new List<Dog>()
            {
                new (){ Name = "Boby"},
                new (){ Name = "Rito"},
                new (){ Name = "Rocky"},
            };
            return Ok(dogs);
        }
    }

    public class Dog
    {
        public string Name { get; set; }
    }
}