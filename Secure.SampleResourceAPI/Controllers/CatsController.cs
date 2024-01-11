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
    public class CatsController : ControllerBase
    {
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public ActionResult<Cat> ListCats()
        {
            var cats = new List<Cat>()
            {
                new (){ Name = "Tom"},
                new (){ Name = "Lu"},
            };
            return Ok(cats);
        }
    }

    public class Cat
    {
        public string Name { get; set; }
    }
}