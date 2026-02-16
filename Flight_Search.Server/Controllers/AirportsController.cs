using Flight_Search.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flight_Search.Server.Controllers
{
    [Route("api/airports")]

    [ApiController]
    public class AirportsController : ControllerBase
    {
        [HttpGet("destinations/{origin}")]
        public IActionResult GetDestinations(string origin)
        {
            if (string.IsNullOrWhiteSpace(origin))
                return BadRequest("Origin airport code is required.");

            if (!AirportData.Destinations.ContainsKey(origin.ToUpper()))
                return NotFound($"No destinations found for origin {origin}.");

            return Ok(AirportData.Destinations[origin.ToUpper()]);
        }

    }
}
