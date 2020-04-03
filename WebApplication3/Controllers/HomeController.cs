using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Login()
        {
            return Content("OK");

            //using (HttpClient client = new HttpClient())
            //{
            //    var model = client.GetStringAsync("http://localhost:5003/api/Home/Login").Result;

            //    return Ok(model);
            //}

            
        }
    }
}