using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ArduinoSite.Models;
using ArduinoSite.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace ArduinoSite.Controllers
{
    [ApiController]
    [Route("/api")]
    public class APIController : ControllerBase
    {
        private readonly IHubContext<CustomHub> _customHub;

        public APIController(IHubContext<CustomHub> customHub) {
            _customHub = customHub;
        }

        [Route("update/temperature")]
        [HttpPost]
        public IActionResult InsertTemp(Temperature temp)
        {
            _customHub.Clients.All.SendAsync("update_temperature", temp);
            return Ok(temp);
        }
        [Route("temperature")]
        [HttpGet]
        public IActionResult GetTemp()
        {
            return Ok("hey");
        }
    }
}
