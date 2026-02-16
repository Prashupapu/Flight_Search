using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Flight_Search.Server.Data;
using Flight_Search.Server.Models;

namespace Flight_Search.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        [HttpGet]
        public IActionResult SearchFlights(string origin, string destination)
        {
            if (string.IsNullOrEmpty(origin) || string.IsNullOrEmpty(destination))
                return BadRequest("Origin and destination are required.");

            var flights = new List<Flight>
            {
                new Flight { Id = 1, Origin = origin, Destination = destination, Price = 500 },
                new Flight { Id = 2, Origin = origin, Destination = destination, Price = 650 }
            };

            return Ok(flights);
        }

    }
}
