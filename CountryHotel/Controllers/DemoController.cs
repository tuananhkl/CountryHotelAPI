using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CountryHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private static CustomServices.CustomServices _customServices = new CustomServices.CustomServices();
        
        [Route("/hello")]
        [HttpGet]
        public IActionResult Greeting(string name)
        {
            string result = _customServices.SayHello(name);

            return Ok(result);
        }
    }
}