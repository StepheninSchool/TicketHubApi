using Azure.Storage.Queues;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using System.Runtime.InteropServices.Marshalling;
using System.Text.Json;

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
        public async Task<IActionResult>Post(Ticket ticket) //stystem automatically will bind to correspoding field in object
        {

            // Validation
            if(string.IsNullOrEmpty(ticket.Email) || string.IsNullOrEmpty(ticket.CreditCard))
            {
                return BadRequest("Email and credit card are required.");
            }

            // Send ticket to azure queue
            string queueName = "tickethub";

            // Get connection string from secrets.json
            string? connectionString = _configuration["AzureStorageConnectionString"];

            if (string.IsNullOrEmpty(connectionString))
            {
                return BadRequest("An error was encountered");
            }

            QueueClient queueClient = new QueueClient(connectionString, queueName);

            // serialize an object to JSON
            string message = JsonSerializer.Serialize(ticket);
            

            // send string message to queue
            await queueClient.SendMessageAsync(message);

            return Ok("Ticket (" + ticket.ConcertId + ") added to azure tickethub queue");
        }
    }
}
