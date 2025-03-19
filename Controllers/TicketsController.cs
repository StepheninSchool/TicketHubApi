using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace TicketHubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ILogger<TicketsController> _logger;
        private readonly IConfiguration _configuration;
        public TicketsController(ILogger<TicketsController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from Tickets controller - GET()");
        }
        [HttpPost]
        public IActionResult Post(Ticket ticket) //stystem automatically will bind to correspoding field in object
        {

            //validation
            if (string.IsNullOrEmpty(ticket.FirstName) || string.IsNullOrEmpty(ticket.LastName))
            {
                return BadRequest("First and Last name is required");
            }
            //save to database
            return Ok("Hello " + ticket.FirstName + " from Tickets controller - POST()");
        }
    }
}
