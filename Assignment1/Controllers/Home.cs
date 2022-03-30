using Assignment1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Home : ControllerBase
    {
        IConfiguration _iconfiguration;
        public Home(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
        }
        [HttpGet]
        public AppSettings credentials([FromQuery]AppSettings obj)
        {
            obj.UserName = _iconfiguration.GetSection("AppSettings").GetSection("UserName").Value.ToString();
            obj.Password = _iconfiguration.GetSection("AppSettings").GetSection("Password").Value.ToString();
            return obj;

        }
    }
}
