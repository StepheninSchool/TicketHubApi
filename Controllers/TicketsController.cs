﻿using Azure.Storage.Queues;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Threading.Tasks;
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
        public async Task<IActionResult> Post(Ticket ticket)
        {
            // Send ticket to Azure queue
            string queueName = "tickethub";

            // Get connection string from configuration
            string? connectionString = _configuration["AzureStorageConnectionString"];

            if (string.IsNullOrEmpty(connectionString))
            {
                _logger.LogError("AzureStorageConnectionString is missing from configuration");
                return BadRequest("An error was encountered.");
            }

            try
            {
                QueueClient queueClient = new QueueClient(connectionString, queueName);

                // Serialize the ticket object to JSON
                string message = JsonSerializer.Serialize(ticket);

                // Send the message to the queue
                await queueClient.SendMessageAsync(message);

                _logger.LogInformation("Ticket ({ConcertId}) added to Azure tickethub queue", ticket.ConcertId);

                return Ok($"Ticket ({ticket.ConcertId}) added to Azure tickethub queue");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending ticket to queue");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error processing ticket");
            }
        }
    }
}